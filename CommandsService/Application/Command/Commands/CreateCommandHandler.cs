using AutoMapper;
using CommandsService.Data.Interfaces;
using CommandsService.Models;
using MediatR;

namespace CommandsService.Application.Command.Commands
{
	public class CreateCommandHandler : IRequestHandler<CreateCommandRequest, ApiResponse<CreateCommandRequest>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse<CreateCommandRequest>> Handle(CreateCommandRequest request, CancellationToken cancellationToken)
		{
			var entity = _mapper.Map<CommandsService.Models.Command>(request);

			Boolean success;
			String Message;
			Models.Command dbResponse;
			CreateCommandRequest response;
			String CodeResult;

			try
			{
				dbResponse = await _unitOfWork.commandRepo.CreateCommand(entity);

				response = _mapper.Map<CreateCommandRequest>(dbResponse);

				if (dbResponse.Id > 0)
				{
					CodeResult = StatusCodes.Status200OK.ToString();
					Message = "Success, and there is a response body";
					success = true;
				}
				else
				{
					CodeResult = StatusCodes.Status400BadRequest.ToString();
					Message = "Command not registered";
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

			return new ApiResponse<CreateCommandRequest>
			{
				CodeResult = CodeResult,
				Message = Message,
				Data = response,
				Success = success
			};

		}
	}
}
