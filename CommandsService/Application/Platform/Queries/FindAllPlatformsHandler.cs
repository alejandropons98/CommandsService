using AutoMapper;
using CommandsService.Data.Interfaces;
using CommandsService.Models;
using MediatR;

namespace CommandsService.Application.Platform.Queries
{
    public class FindAllPlatformsHandler : IRequestHandler<FindAllPlatformsRequest, ApiResponse<IReadOnlyList<FindAllPlatformsRequest>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindAllPlatformsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<IReadOnlyList<FindAllPlatformsRequest>>> Handle(FindAllPlatformsRequest request, CancellationToken cancellationToken)
        {
            bool success;
            string Message;
            IReadOnlyList<Models.Platform> list;
            IReadOnlyList<FindAllPlatformsRequest> dbResponse;
            string CodeResult;

            try
            {
                list = await _unitOfWork.commandRepo.FindAll();

                if (list.Count > 0)
                {
                    dbResponse = _mapper.Map<IReadOnlyList<FindAllPlatformsRequest>>(list);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"Not Found";
                    dbResponse = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                dbResponse = null;
                success = false;
            }

            return new ApiResponse<IReadOnlyList<FindAllPlatformsRequest>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = dbResponse,
                Success = success
            };
        }
    }
}
