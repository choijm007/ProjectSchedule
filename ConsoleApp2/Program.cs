using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

// 2021203061 김인효
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient();  // TcpClient 객체를 생성
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");  // 로컬 IP 주소 설정
                int port = 13000;  // 사용할 포트 번호
                client.Connect(localAddr, port);  // 서버에 연결

                NetworkStream stream = client.GetStream();  // 데이터 통신을 위한 스트림 얻기
                byte[] readBuffer = new byte[sizeof(int)];  // 데이터를 읽기 위한 버퍼 준비

                // 버퍼 크기 읽기
                stream.Read(readBuffer, 0, readBuffer.Length);  // 버퍼에서 데이터 읽기
                int bufferSize = BitConverter.ToInt32(readBuffer, 0);  // 읽은 데이터를 정수로 변환
                Console.WriteLine("Received: {0}", bufferSize);  // 버퍼 크기 출력

                // 메시지 읽기
                readBuffer = new byte[bufferSize];
                int bytes = stream.Read(readBuffer, 0, readBuffer.Length);  // 메시지 읽기
                string message = Encoding.UTF8.GetString(readBuffer, 0, bytes);  // 바이트 배열을 문자열로 변환
                Console.WriteLine("Received: {0}", message);  // 메시지 출력

                stream.Close();  // 스트림 닫기
                client.Close();  // 클라이언트 연결 닫기
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);  // 소켓 예외 발생시 출력
            }
            finally
            {
                client?.Close();  // 클라이언트 연결이 있다면 닫기
                Console.WriteLine("계속 하시려면 아무 키나 누르세요.");
                Console.ReadKey();  // 키 입력 대기
            }
            Console.WriteLine("Client Exit");  // 클라이언트 종료 메시지
        }
    }
}
