using Common.Handlers;
using Common.RabbitMQ;
using Common.Repo;
using ProductService.Commands;
using ProductService.Events;
using ProductService.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.CommandHandlers
{
    public class NewProductCommandHandler : ICommandHandler<NewProductCommand>
    {
        IBusPublisher _busPublisher;
        public NewProductCommandHandler(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        } 
        public async Task  HandleAsync(NewProductCommand command, ICorrelationContext context)
        {
           var enumerator = DataStore<Product>.GetInstance().GetRecords(i=>i.Name == command.Name) ;
            if (enumerator.Count() == 0 )
            {
                DataStore<Product>.GetInstance().AddRecord
                    (new Product(command.Id, command.Name, command.Category, command.Price));
                //Send product created event bus msg
                await _busPublisher.PublishAsync<ProductCreated>( new ProductCreated { Id = command.Id, Name = command.Name, Context = context }, context);
            }
            else
            {
                //Send rejected bus message
            }
            
            
        }
    }
}
