﻿using NServiceBus;
using __NAME__.Domain;
using __NAME__.Messages.Commands;

namespace __NAME__.MessageBus.Handlers.ForMessages
{
    public class CloseExampleHandler : IHandleMessages<CloseExampleCommand>
    {
        private readonly IRepository _repository;

        public CloseExampleHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CloseExampleCommand message)
        {
            var entity = _repository.Load<ExampleEntity>(message.Id);
            entity.Close();
            _repository.Save(entity);
        }
    }
}
