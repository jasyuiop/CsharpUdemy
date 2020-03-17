using System;
using System.Collections.Generic;
using System.Text;

namespace KendiHataSinifimiziYazalim
{
    class RecordNotFoundException : Exception // Exception'dan inherite ettik.
    {
        // örneğin veri tabanı veya listede bir kayıt aranıyor fakat bulunamıyor.

        // throwda hatayı buraya fırlatırken message'i direkt olarak gönderemiyoruz
        // göndermek için sınıfımıza bir yapıcı oluşturup string parametre alıp 
        // base alınan sınıfa bu aldığımız parametreyi yolluyoruz.
        public RecordNotFoundException(string message):base(message)
        {

        }
    }
}
