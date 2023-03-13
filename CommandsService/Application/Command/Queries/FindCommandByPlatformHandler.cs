using AutoMapper;
using CommandsService.Application.Platform.Queries;
using CommandsService.Data.Interfaces;
using CommandsService.Models;
using MediatR;

namespace CommandsService.Application.Command.Queries
{
	public class FindCommandByPlatformHandler : IRequestHandler<FindCommandByPlatformRequest, ApiResponse<FindAllCommandsByPlatformRequest>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public FindCommandByPlatformHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<FindAllCommandsByPlatformRequest>> Handle(FindCommandByPlatformRequest request, CancellationToken cancellationToken)
		{
			Boolean success;
			String Message;
			Models.Command dbResponse;
			FindAllCommandsByPlatformRequest response;
			String CodeResult;

			try
			{
				dbResponse = await _unitOfWork.commandRepo.GetCommand(request.PlatformId, request.Id);

				if (dbResponse != null)
				{
					response = _mapper.Map<FindAllCommandsByPlatformRequest>(dbResponse);
					CodeResult = StatusCodes.Status200OK.ToString();
					Message = "Success, and there is a response body.";
					success = true;
				}
				else
				{
					CodeResult = StatusCodes.Status404NotFound.ToString();
					Message = $"Command with ID {request.Id} and Platform ID {request.PlatformId} Not Found";
					response = null;
					success = false;
				}
			}
			catch (Exception ex)
			{

				CodeResult = StatusCodes.Status500InternalServerError.ToString();
				Message = "Internal Server Error";
				success = false;
				response = null;
			}

			return new ApiResponse<FindAllCommandsByPlatformRequest>
			{
				CodeResult = CodeResult,
				Message = Message,
				Data = response,
				Success = success
			};
		}
	}
}
