using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Context;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRepository
    {
        private readonly IMongoCollection<ItemPedido> _itensPedidoCollection;

        public ItemPedidoRepository(DataBaseContext dataBaseContext, IMongoDatabase mongoDatabase)
            : base(dataBaseContext)
        {
            _itensPedidoCollection = mongoDatabase.GetCollection<ItemPedido>("ItensPedido");
        }

        public async Task<IList<ItemPedido>> ObterItensDosPedidos()
        {
            return await _itensPedidoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IList<ItemPedido>> ObterItensDoPedido(Guid pedidoId)
        {
            return await _itensPedidoCollection.Find(x => x.PedidoId == pedidoId).ToListAsync();
        }

        public async Task<bool> InserirItemPedido(ItemPedido itemPedido)
        {
            try
            {
                await _itensPedidoCollection.InsertOneAsync(itemPedido);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AtualizarQuantidadeItemPedido(ItemPedido itemPedido)
        {
            try
            {
                var result = await _itensPedidoCollection.FindOneAndUpdateAsync(
                t => t.Id == itemPedido.Id,
                Builders<ItemPedido>.Update
                    .Set(t => t.Quantidade, itemPedido.Quantidade));

                return result != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}