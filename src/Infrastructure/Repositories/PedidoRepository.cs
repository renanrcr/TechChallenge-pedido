using Infrastructure.Context;
using Domain.Entities;
using Domain.Adapters;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        private readonly IMongoCollection<Pedido> _pedidoCollection;

        public PedidoRepository(DataBaseContext dataBaseContext, IMongoDatabase mongoDatabase)
            : base(dataBaseContext)
        {
            _pedidoCollection = mongoDatabase.GetCollection<Pedido>("Pedidos");
        }

        public async Task<IList<Pedido>> ObterPedido()
        {
            return await _pedidoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<bool> InserirPedido(Pedido pedido)
        {
            try
            {
                await _pedidoCollection.InsertOneAsync(pedido);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AtualizarStatusDoPedido(Pedido pedido)
        {
            try
            {
                var result = await _pedidoCollection.FindOneAndUpdateAsync(
                t => t.Id == pedido.Id,
                Builders<Pedido>.Update
                    .Set(t => t.StatusPedido, pedido.StatusPedido));

                return result != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletarPedido(Guid idPedido)
        {
            try
            {
                var result = await _pedidoCollection.DeleteOneAsync(t => t.Id == idPedido);

                return result != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}