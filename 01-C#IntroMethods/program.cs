
//1
// class Proqram
// {
//     static void Main()
//     {
//         Console.Clear();
//         int result1=topla(3,4);
//         int result2=cix(4,2);
//         int result3=vur(2,3);
//         int result4= bol(8,2);
//         System.Console.WriteLine(result1);
//         System.Console.WriteLine(result2);
//         System.Console.WriteLine(result3);
//         System.Console.WriteLine(result4);
//     }
//     static int  topla(int num1, int num2)
//     {
//         return num1+num2;
//     }
//         static int  cix(int num1, int num2)
//     {
//         return num1-num2;
//     }
//         static int  vur(int num1, int num2)
//     {
//         return num1*num2;
//     }
//         static int  bol(int num1, int num2)
//     {
//         return num1/num2;
//     }
// }


//2
// class Proqram
// {
//     static void Main()
//     {
//         Console.Clear();
//         int [] num={14, 20, 35, 40, 57, 60, 100};
//         newnum(num);
//     }
//     static void newnum(int [] num)
//     {
//         string tek=" ";
//         string cut=" ";
//         for (int i = 0; i < num.Length; i++)
//         {
//             if (num[i] % 2 == 0)
//                 cut += num[i] + " ";
//             else
//                 tek += num[i] + " ";
//         }
//         System.Console.WriteLine("tek ededler: "+tek);
//         System.Console.WriteLine("cut ededler: "+cut);
//     }
// }

//3
// using System;
// class Proqram
// {
//     static void Main()
//     {
//         Console.Clear();
//         int[] arr = { 14, 20, 35, 40, 57, 60, 100 };
//         int sum = Narr(arr); 
//         Console.WriteLine(sum); 
//     }
//     static int Narr(int[] num)
//     {
//         int sum = 0;

//         for (int i = 0; i < num.Length; i++)
//         {
//             if (num[i] % 4 == 0 && num[i] % 5 == 0)
//             {
//                 sum += num[i];
//             }
//         }
//         return sum;
//     }
// }

//4
// class Proqram
// {
//     static void Main()
//     {
//         Console.Clear();
//         string cumle="men derse gedirem";
//         char simvol='e';      
//         int netice = simvolsayi(cumle,simvol);
//         System.Console.WriteLine(cem);
//     }
//     static int simvolsayi(string cumle,char herf)
//     {
//         int count=0;
//         for (int i = 0; i < cumle.Length; i++)
//         {
//             if (cumle[i]==herf)
//             {
//                 count++;
//             }
//         }
//         return count;
//     }
// }
