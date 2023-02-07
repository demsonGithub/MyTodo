using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Application.Commands
{
    public class GetTokenCommandHandler : IRequestHandler<GetTokenCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public GetTokenCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(GetTokenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetUserByAccountPwd(request.Account, request.Password);

            if (entity == null)
            {
                return string.Empty;
            }

            // todo: generate token

            return entity.Id.ToString();
        }
    }
}