namespace Entities
{
    public class Category : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category()
        {
            
        }

        // kullancaksan ekle
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
