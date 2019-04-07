using System;

namespace PrimaryCore
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true){
                Console.WriteLine("Hello my fat friend!");
                Console.WriteLine("Введи пожалуйста свой рост в см.");
                var sHeight = Console.ReadLine();
                double height;
                if(!double.TryParse(sHeight, out height) || height == 0){
                    Console.WriteLine("Число введено не верно. Нажми любую кнопку.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("Введи пожалуйста свой вес в кг.");
                var sWeight = Console.ReadLine();
                double weight;
                if(!double.TryParse(sWeight, out weight)){
                    Console.WriteLine("Число введено не верно. Нажми любую кнопку.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                var imt = (weight * 10000)/ (height * height); // если рост в см, то нужен коэффициент 10000
                
                Console.WriteLine("Индекс массы тела получается:{0}",imt.ToString("n2"));
                // Далее выводы для тел мужского пола от 19 до 25 лет и женского до 24 лет
                if(imt <= 18.5){
                    Console.WriteLine("Дифицит массы тела");
                }
                else if(imt < 25){
                    Console.WriteLine("Нормальная масса тела");
                }else if(imt < 30){                    
                    Console.WriteLine("Повышенная масса тела, это ещё предожирение, но надо посмотреть над отношением массы жира и мышц.");
                }else if(imt < 35){                    
                    Console.WriteLine("Это ожирение I степени, мой пухлячок, подумай о правильном питании и регулярных тренировках.");
                }else if(imt < 40){
                    Console.WriteLine("Это ожирение II степени, мой жирненький дружок. Задумайся всерьез над правильным питанием и усиленным тренингом.");
                }else if(imt < 150){
                    Console.WriteLine("Это ожирение III степени, дружок, пора бы всерьез взяться за себя, иначе сдохнешь очень скоро.");
                }else {
                    Console.WriteLine("Тебе уже ничего не поможет, мой слоник. :( покойся с миром");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
            
    }
}