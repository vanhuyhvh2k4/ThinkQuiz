using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThinkQuiz.Application.Users.Commands;
using ThinkQuiz.Contracts.Users;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThinkQuiz.Api.Controllers.V1
{
    public class UserController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _validator;

        public UserController(IMapper mapper, ISender validator)
        {
            _mapper = mapper;
            _validator = validator;
        }


        [HttpPatch("users/{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, UpdateUserRequest request)
        {
            var command = _mapper.Map<UpdateUserCommand>((request, userId));

            var updateUserResult = await _validator.Send(command);

            return updateUserResult.Match(
               updateUserResult => Ok(_mapper.Map<UpdateUserResponse>(updateUserResult)),
               errors => Problem(errors)
               );
        }
    }
}

