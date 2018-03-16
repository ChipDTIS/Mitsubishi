
using NC20.Entities;
namespace NC20.Repository
{
    public partial class ClaimRepository : BaseRepository<Claim, NC20Entities>, IClaimRepository
    {
        public ClaimRepository(IBaseUnitOfWork<NC20Entities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(Claim model)
        {
            return model.Id;
        }
	}
    public partial class ImageRepository : BaseRepository<Image, NC20Entities>, IImageRepository
    {
        public ImageRepository(IBaseUnitOfWork<NC20Entities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(Image model)
        {
            return model.Id;
        }
	}
    public partial class RoleRepository : BaseRepository<Role, NC20Entities>, IRoleRepository
    {
        public RoleRepository(IBaseUnitOfWork<NC20Entities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(Role model)
        {
            return model.Id;
        }
	}
    public partial class RoleClaimRepository : BaseRepository<RoleClaim, NC20Entities>, IRoleClaimRepository
    {
        public RoleClaimRepository(IBaseUnitOfWork<NC20Entities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(RoleClaim model)
        {
            return model.Id;
        }
	}
    public partial class UserRepository : BaseRepository<User, NC20Entities>, IUserRepository
    {
        public UserRepository(IBaseUnitOfWork<NC20Entities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(User model)
        {
            return model.Id;
        }
	}
    public partial class UserLoginTokenRepository : BaseRepository<UserLoginToken, NC20Entities>, IUserLoginTokenRepository
    {
        public UserLoginTokenRepository(IBaseUnitOfWork<NC20Entities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(UserLoginToken model)
        {
            return model.Id;
        }
	}
    public partial class UserProfileRepository : BaseRepository<UserProfile, NC20Entities>, IUserProfileRepository
    {
        public UserProfileRepository(IBaseUnitOfWork<NC20Entities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(UserProfile model)
        {
            return model.Id;
        }
	}
    public partial class UserRoleRepository : BaseRepository<UserRole, NC20Entities>, IUserRoleRepository
    {
        public UserRoleRepository(IBaseUnitOfWork<NC20Entities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(UserRole model)
        {
            return model.Id;
        }
	}
}