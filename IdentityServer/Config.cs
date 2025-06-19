using Duende.IdentityServer.Models;

namespace IdentityServer
{
    public static class Config
    {
        // ApiScope: Servislerin kullanacağı yetkilendirme kapsamlarını tanımlar.
        // Her servis için "okuma", "yazma" gibi farklı yetkilendirme kapsamları oluşturulabilir.
        public static IEnumerable<ApiScope> GetApiScopes() =>
            [
            // ServiceA'ya ait okuma ve yazma kapsamları
            new ApiScope("serviceA.read", "Servis A Okuma Yetkisi"),
            new ApiScope("serviceA.write", "Servis A Yazma Yetkisi"),
        ];

        // ApiResource: Hangi servislerin olduğunu ve hangi izinlere sahip olduklarını tanımlar.
        public static IEnumerable<ApiResource> ApiResources =>
            [
            // ServiceA'ya ait kaynak tanımı
            new ApiResource("serviceA", "Servis A")
            {
                Scopes = { "serviceA.read", "serviceA.write" } // Bu kaynak için izin verilen kapsamlar
            }
            ];

        // Client: Servislerin kimlik doğrulama ve yetkilendirme için kullanacağı istemcileri tanımlar.
        public static IEnumerable<Client> Clients => [
            new Client{
                ClientId = "clientA", // İstemci kimliği

                ClientName = "Client A", // İstemci adı

                // SHA256: Güvenlik için kullanılan şifreleme algoritması. Belirtilen metni SHA256 ile şifreler.
                ClientSecrets = {new Secret("secretA".Sha256())}, // Güvenlik için belirlenen gizli anahtar.

                // ClientCredentials: Kimlik bilgileri ile kimlik doğrulama yapacak istemciler için kullanılır.
                AllowedGrantTypes = GrantTypes.ClientCredentials, 

                // İzin verilen API kapsamları
                AllowedScopes = { "serviceA.read", "serviceA.write" },
            }
            ];
    }
}
