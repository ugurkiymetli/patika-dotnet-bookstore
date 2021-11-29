using System;

namespace BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorDetailQuery
{
    public class GetAuthorDetailQueryModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
