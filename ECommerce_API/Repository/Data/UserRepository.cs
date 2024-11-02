using ECommerce_API.Models;
using ECommerce_API.Parent;
using ECommerce_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ViewModel;

namespace ECommerce_API.Repository.Data
{
    public class UserRepository: BaseRepository<MUser,VMMUser, int, DB_Market_PlaceContext>, IUserRepository
    {
        public UserRepository(DB_Market_PlaceContext _context) : base(_context) { }

        public async Task<VMResponse<VMMBiodata>?> LoginAsync(VMLogin login)
        {
            // Cek apakah pengguna dengan email tersebut ada
            MUser? user = await _context.MUsers
                .Where(u => u.Email == login.Email && u.IsDeleted == false)
                .FirstOrDefaultAsync();

            MBiodatum? userData = await _context.MBiodata
                .Where(u => u.UserId == user!.Id && u.IsDeleted == false)
                .FirstOrDefaultAsync();

            // Jika pengguna tidak ditemukan, kembalikan respons "User not found"
            if (user == null || userData == null)
            {
                return new VMResponse<VMMBiodata>
                {
                    statusCode = HttpStatusCode.NotFound,
                    message = "User not found"
                };
            }

            // Cek password apakah sesuai dengan hash password yang tersimpan
            //bool isPasswordValid = BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash);

            if (login.Password != user.Password)
            {
                return new VMResponse<VMMBiodata>
                {
                    statusCode = HttpStatusCode.Unauthorized,
                    message = "Invalid password"
                };
            }

            return new VMResponse<VMMBiodata>
            {
                statusCode = HttpStatusCode.OK,
                message = "Login successful",
                data = new VMMBiodata
                {
                    BiodataId = userData.Id,
                    UserId = user.Id,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    Gender = userData.Gender,
                    BirthDate = userData.BirthDate,
                    PhoneNumber = userData.PhoneNumber,
                }
            };
        }


        public async Task<VMResponse<VMMUser>?> RegisterAsync(VMRegister register)
        {
            // Cek apakah pengguna sudah ada berdasarkan email
            MUser? existingUser = await _context.MUsers.Where(u => u.Email == register.Email && u.IsDeleted == false).FirstOrDefaultAsync();

            if (existingUser != null)
            {
                return new VMResponse<VMMUser>
                {
                    statusCode = HttpStatusCode.Conflict,
                    message = "User already exists."
                };
            }

            // Memulai transaksi database
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Buat entitas pengguna baru
                MUser newUser = new MUser
                {
                    Email = register.Email,
                    Password = register.Password, // Pastikan untuk hashing password sebelum menyimpan
                    PhoneNumber = register.PhoneNumber,
                    RoleId = register.RoleId,
                    CreatedOn = DateTime.Now,
                    CreatedBy = 1 // atau ID pengguna yang membuat akun, jika ada
                };

                // Tambah pengguna ke dalam context
                await _context.MUsers.AddAsync(newUser);
                await _context.SaveChangesAsync();

                // Buat entitas biodata baru yang terhubung ke pengguna baru
                MBiodatum newBiodata = new MBiodatum
                {
                    UserId = newUser.Id,
                    FirstName = register.FirstName!,
                    LastName = register.LastName,
                    PhoneNumber = register.PhoneNumber,
                    CreatedOn = DateTime.Now,
                    CreatedBy = 1 // atau ID pengguna yang membuat biodata
                };

                // Tambah biodata ke dalam context
                await _context.MBiodata.AddAsync(newBiodata);
                await _context.SaveChangesAsync();

                // Commit transaksi jika semua operasi berhasil
                await transaction.CommitAsync();

                return new VMResponse<VMMUser>
                {
                    statusCode = HttpStatusCode.Created,
                    message = "User registered successfully.",
                    data = new VMMUser
                    {
                        Email = newUser.Email,
                        Password = newUser.Password, // Pastikan untuk hashing password sebelum menyimpan
                        PhoneNumber = newUser.PhoneNumber,
                        RoleId = newUser.RoleId,
                        CreatedOn = newUser.CreatedOn,
                    }
                };
            }
            catch (Exception ex)
            {
                // Rollback transaksi jika terjadi kesalahan
                await transaction.RollbackAsync();

                return new VMResponse<VMMUser>
                {
                    statusCode = HttpStatusCode.InternalServerError,
                    message = "Registration failed: " + ex.Message
                };
            }
        }

        public Task<VMResponse<bool>?> SendOTP(VMLogin login)
        {
            throw new NotImplementedException();
        }
    }
}
