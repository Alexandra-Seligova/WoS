
namespace WoS_Server.Services
{
    // Services/WoSServiceImpl.cs
    using System.Threading.Tasks;
    using Grpc.Core;
    using WoS_Server.DB_Model;
    using WoS_Server; // Namespace generovaného kódu z .proto souboru


    public class WoSServiceImpl : WoSService.WoSServiceBase
    {
        private readonly WoS_Db_Context _context;

        public WoSServiceImpl(WoS_Db_Context context)
        {
            _context = context;
        }
        /*
        public override Task<GetUserResponse> GetUser(GetUserRequest request, ServerCallContext context)
        {
            var user = _context.Users.Find(request.UserId);
            if(user == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "UserModel not found"));
            }

            var response = new GetUserResponse
            {
                Id = user.Id,
                IsLocked = user.IsLocked,
                Nickname = user.Nickname,
                Email = user.Email,
                // Add other fields as necessary
            };

            return Task.FromResult(response);
        }

        */






    }
}
