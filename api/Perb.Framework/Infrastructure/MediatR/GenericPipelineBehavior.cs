using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Perb.Framework.Logging;

namespace Perb.Framework.Infrastructure.MediatR
{
    public class GenericPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private static readonly ILog Logger = LogProvider.For<GenericPipelineBehavior<TRequest, TResponse>>();

        public GenericPipelineBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Logger.Info("-- Handling Request");
            try
            {
                _unitOfWork.Begin();
                
                var response = await next();
                Logger.Info("-- Finished Request");
                
                _unitOfWork.Commit();
                
                return response;
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                
                Logger.ErrorException("Erro ao executar request {RequestType}.", e, request.GetType());
                throw;
            }
        }
    }
}