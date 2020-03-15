using System;

namespace ParameterToBaseClassWithConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonManager personManager = new PersonManager("Product");
            personManager.Add();
        }
    }
    class BaseClass
    {
        // entity varlık demek bu arada :)
        private string _entity;
        public BaseClass(string entity)
        {
            _entity = entity;
        }
        public void Message()
        {
            Console.WriteLine("{0} mesage",_entity);
        }
    }
    class PersonManager : BaseClass
    {
        // BaseClass bir yapıcı metota sahip ve yapıcı metotu bir parametre alıyor
        // PersonManager sınıfından o parametreyi BaseClass'ına geçmemiz lazım ->
        public PersonManager(string entity):base(entity)
        {
            // PersonManagere de bi yapıcı oluşturup base sınıfında göndereceğimiz parametreyi alıp, gönderiyoruz.
        }
        public void Add()
        {
            Console.WriteLine("Added!");
            Message();
        }
    }
}
