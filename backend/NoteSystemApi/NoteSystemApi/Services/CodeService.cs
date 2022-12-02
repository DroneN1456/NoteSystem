using System.Text;
using System.Web;
namespace NoteSystemApi.Services
{

    public static class CodeService
    {
        public static string RandomString(int size){
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            char ch;
            for(int i = 0; i < size; i++){
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                sb.Append(ch);
            }
            return sb.ToString();
            
        }


        public static string GenerateCode(){
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for(int i =0; i<10; i++){
                if(rand.Next(0, 2) == 1){
                    sb.Append(RandomString(1));
                }else{
                    sb.Append(rand.Next(0, 10));
                }
            }
            return sb.ToString();
        }
    }
}