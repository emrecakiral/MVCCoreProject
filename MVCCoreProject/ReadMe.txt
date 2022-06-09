
1) Entity objesi oluşturulur.. Entities klasörü içerisine...

2) Eğer oluşturulan obje ile veritabanı objesi arasında isim farklılıkları ve tip farklıları varsa EntitiesConfiguration klasörü içerisine EntityNameConfiguration dosyası eklenir (CategoryCOnfigurationı örnek alabiliriz) (EntitiesConfiguraion klasörü)

3) EntityObjlerinde Model atributeleri kullanmamak adına ViewModel klasörüne Entity ismi ile aynı bir class eklenir.. ( ViewModel Klasöründe)

4) Entity objeleri ve ViewModel objelerini eşleştirmek için AUTOMAPPER kütüphanesi kullanılır.. (bunu biz kurduk) (MappingProfile)

5) Veritabanı sorgulamaların sorumluluğu Repository sınfılarına verilir. Örnek CategoryRepository oluşturuldu. veritabanı işlemleri bu sınıf içerisnde yapıldı (Repository Klasöründe)

6) Controller sınıfı Repository Interfacesinden instqance alacak şekilde düzenlendi ve Program.cs sınıfında instane gönderildi...

7) Controller eklerkende add -controller seçeneinde empty-controller değil, controller with read,write actionlu template seçilirse  controller içerisinde crud operasyonlarını yapacağımız boş actionlar gelecektir. Bu actionlara sağ tık yapıp 8 adım izlenebilir. Ayrıca bu konu scaffolding template olarak araştırabilirsiniz...

8) Viewlar oluşturulruken Scaffolding template yapısını kullandık. Bu yüzden view eklerken add view seçeneğinden önce Template view ne için ekleniyorsa onun için seçilmeli (örn List) . Daha sonra bu viewin modeli Models'den seçilmeli (örneğin categoryviewmodel).. 



7) Yapılacak tek şey örneğin ShipperContoller için CategroyControllerdaki adımları izlemek..
(Shippers-Recep)
(Customer-Alper)
(Products- Emre) (ProductName,UnitPrice,UnitsInStock) diğerleri sana kalmış...
([Region]-Bilal)
(Suppliers-Ahmet)

githuba yüklediğim projei clone ile alıp, sadece sizden istenilen modülleri geliştiriniz. işiniz bittikten sonra commit-push yapmayı unutmayınız.....
