using AutoMapper;
using CommandsService.Application.Platform.Queries;
using CommandsService.Data.Interfaces;
using CommandsService.Models;
using MediatR;

namespace CommandsService.Application.Command.Queries
{
	public class FindAllCommandsByPlatformHandler : IRequestHandler<FindAllCommandsByPlatformRequest, ApiResponse<IReadOnlyList<FindAllCommandsByPlatformRequest>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public FindAllCommandsByPlatformHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<ApiResponse<IReadOnlyList<FindAllCommandsByPlatformRequest>>> Handle(FindAllCommandsByPlatformRequest request, CancellationToken cancellationToken)
		{
			Boolean success;
			String Message;
			IReadOnlyList<Models.Command> list;
			IReadOnlyList<FindAllCommandsByPlatformRequest> dbResponse;
			String CodeResult;

			try
			{
				list = await _unitOfWork.commandRepo.GetCommandsForPlatform(request.PlatformId);

				if (list.Count > 0)
				{
					dbResponse = _mapper.Map<IReadOnlyList<FindAllCommandsByPlatformRequest>>(list);

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

			return new ApiResponse<IReadOnlyList<FindAllCommandsByPlatformRequest>>
			{
				CodeResult = CodeResult,
				Message = Message,
				Data = dbResponse,
				Success = success
			};
		}
	}
}
