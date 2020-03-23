using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc2.Introduction.Services
{
    /*Dependency Injection örneği yaptık burada 8 ve 18 olmak üzere iki tane kdv tutarımız için
     2 ayrı class oluşturup ICalculator'ü bunlara inherite ettim, daha sonra implemente edip
     startup dosyamızda ICalculator tipinden birşey isteyene Calculator18'i göndermesini söyledim.
     
     böylelikle parametre geçişleri vb.. uğraşmadan EmployeeControllerin yapıcısında ICalculator tipine
     sahip parametre alıp bunu private ICalculator tipinde bir değişkende tuttum, artık
     8lik mi 18lik mi kdv tutarı hesaplayacağız bildiğimiz için sadece Calculate metotunu çağırıp
     işlemi gerçekleştirdim.
     Dependency Injection kullanırsam bu tarz şeylerde büyük oranda if'lerden kurtulur ve daha güzel bir
     yapı elde ederim.
     Dependency Injection NESNELERİN BİRBİRİNDEN BAĞIMSIZ OLACAK DER, BİRİNDE YAPTIĞIN DİĞERİNİ ETKİLEMEYECEK.
     (loglama,cache,auth,db, busness layer, bunları bu yapıyla kullanmak en doğrusu!)
     */
    public interface ICalculator
    {
        // %8 ve %18 kdvye göre hesaplayacak
        decimal Calculate(decimal amount);
    }
}
