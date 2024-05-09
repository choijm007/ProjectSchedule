using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

// 2021203061 김인효
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");  // 로컬 IP 주소 설정
            int port = 13000;  // 사용할 포트 번호
            try
            {
                server = new TcpListener(localAddr, port);  // TcpListener 시작
                server.Start();  // 서버 시작

                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");  // 연결 대기 메시지
                    TcpClient client = server.AcceptTcpClient();  // 클라이언트 연결 수락
                    Console.WriteLine("Connected!");  // 연결 완료 메시지

                    DateTime t = DateTime.Now;  // 현재 시간 저장
                    // 메시지 포맷
                    string message = string.Format("서버에서 보내는 메시지 {0}", t.ToString("yyyy-MM-dd hh:mm:ss"));
                    byte[] writeBuffer = Encoding.UTF8.GetBytes(message);  // 문자열을 바이트 배열로 변환

                    int bytes = writeBuffer.Length;  // 메시지 길이
                    byte[] writeBufferSize = BitConverter.GetBytes(bytes);  // 길이를 바이트 배열로 변환

                    // 클라이언트에 데이터 전송
                    NetworkStream stream = client.GetStream();
                    stream.Write(writeBufferSize, 0, writeBufferSize.Length);  // 버퍼 크기 전송
                    Console.WriteLine("Sent: {0}", bytes);
                    stream.Write(writeBuffer, 0, writeBuffer.Length);  // 메시지 전송
                    Console.WriteLine("Sent: {0}", message);

                    stream.Close();  // 스트림 닫기
                    client.Close();  // 클라이언트 연결 닫기
                    Console.WriteLine();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException:{0}", e);  // 소켓 예외 발생시 출력
            }
            finally
            {
                server.Stop();  // 서버 중지
            }
            Console.WriteLine("\n서버가 종료됩니다.");  // 서버 종료 메시지
        }
    }
}
