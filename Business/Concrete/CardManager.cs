﻿using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult Add(Card card)
        {
            _cardDal.Add(card);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Card>> GetAllCards()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Card> GetbyCardNumber(string cardNumber)
        {
            var getCardNumber = _cardDal.Get(u => u.CardNumber == cardNumber);
            return new SuccessDataResult<Card>(getCardNumber);
        }

        public IDataResult<Card> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(c => c.CustomerId == id));
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult(Messages.Updated);
        }
    }
}
