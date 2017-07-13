using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.Services
{
    public class CardService : IService<Card>
    {
        private readonly IRepository<Card> _cardRepository;

        public CardService(IRepository<Card> cardRepository)
        {
            this._cardRepository = cardRepository;
        }
        public void Create(Card card)
        {
            _cardRepository.Add(card);
        }

        public void Delete(Card card)
        {
            _cardRepository.Delete(card);
        }

        public IEnumerable<Card> GetAll(string name = null)
        {
            return string.IsNullOrEmpty(name)
              ? _cardRepository.GetAll()
              : _cardRepository.GetAll().Where(c => c.FirstName == name);
        }

        public Card GetById(int id)
        {
            var card = _cardRepository.GetById(id);
            return card;
        }

        public Card GetByName(string name)
        {
            return _cardRepository.GetByName(name);
        }
    }
}
