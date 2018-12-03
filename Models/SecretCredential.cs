namespace dell_credhub_demo.Models
{
    public class SecretCredential
    {
        public SecretCredential(string connectionString) {
            this.ConnectionString = connectionString;
        }
        
        public string ConnectionString { get; set; }
    }
}