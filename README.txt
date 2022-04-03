Uygulamayı 2 proje halinde oluşturdum. API tarafını .net core üzerinde oluşturdum. Web tarafını .net framework üzerinde API
ile haberleşecek şekilde kurgulamadım.

API tarafından dikkat edilmesi gerekenler,(BookApi içerisindeki proje)

sistem hatalarının db aktarılması için Log4net.config dosyasın içerisinde
connectionString kısmına db connection stringinin düzenlenmesi gerekiyor.


local db sunucusu üzerinde Depos isminde bir db oluşturup zip li dosya içerisinde bulunan DbScripts.sql içerisindeki script 
çalıştırdığınıda örnek datalar ile ilgili tablolar oluşacaktır. Daha sonra;
_DataAccess layer altında ProjectConfigConst.cs içerisinde DEPOS_SQL_DB_CONNECTION_STRING değişkeninin güncel şekilde doldurulmasından
sonra api tarafı çalışacaktır.

WEB sitesi tarafında ise (eCommerceWeb içerisindeki proje)

Tüm örnekleri Default.aspx içerinde yapılabilir şekilde oluşturdum.
ApiURL değişkenini apinin güncel adresi ile değiştirilmesi gerekmektedir.




