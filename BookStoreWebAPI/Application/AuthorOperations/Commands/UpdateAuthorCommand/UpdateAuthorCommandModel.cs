using System;

namespace BookStoreWebAPI.Application.AuthorOperations.Commands.CreateAuthorCommand
{
    public class UpdateAuthorCommandModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
