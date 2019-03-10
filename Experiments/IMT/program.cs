using System;

namespace PrimaryCore
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true){
                Console.WriteLine("Hello my fat friend!");
                Console.WriteLine("����� ���������� ���� ���� � ��.");
                var sHeight = Console.ReadLine();
                double height;
                if(!double.TryParse(sHeight, out height) || height == 0){
                    Console.WriteLine("����� ������� �� �����. ����� ����� ������.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("����� ���������� ���� ��� � ��.");
                var sWeight = Console.ReadLine();
                double weight;
                if(!double.TryParse(sWeight, out weight)){
                    Console.WriteLine("����� ������� �� �����. ����� ����� ������.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                var imt = (weight * 10000)/ (height * height); // ���� ���� � ��, �� ����� ����������� 10000
                
                Console.WriteLine("������ ����� ���� ����������:{0}",imt.ToString("n2"));
                // ����� ������ ��� ��� �������� ���� �� 19 �� 25 ��� � �������� �� 24 ���
                if(imt <= 18.5){
                    Console.WriteLine("������� ����� ����");
                }
                else if(imt < 25){
                    Console.WriteLine("���������� ����� ����");
                }else if(imt < 30){                    
                    Console.WriteLine("���������� ����� ����, ��� ��� ������������, �� ���� ���������� ��� ���������� ����� ���� � ����.");
                }else if(imt < 35){                    
                    Console.WriteLine("��� �������� I �������, ��� ��������, ������� � ���������� ������� � ���������� �����������.");
                }else if(imt < 40){
                    Console.WriteLine("��� �������� II �������, ��� ���������� ������. ��������� ������� ��� ���������� �������� � ��������� ���������.");
                }else if(imt < 150){
                    Console.WriteLine("��� �������� III �������, ������, ���� �� ������� ������� �� ����, ����� �������� ����� �����.");
                }else {
                    Console.WriteLine("���� ��� ������ �� �������, ��� ������. :( ������� � �����");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
            
    }
}