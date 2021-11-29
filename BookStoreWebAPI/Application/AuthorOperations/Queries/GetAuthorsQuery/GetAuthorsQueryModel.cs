using System;

namespace BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorsQuery
{
    public class GetAuthorsQueryModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
