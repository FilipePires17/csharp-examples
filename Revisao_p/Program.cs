using System;

namespace Revisao_p
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1. Cadastrar aluno");
            Console.WriteLine("2. Listar alunos cadastrados");
            Console.WriteLine("3. Calcular média geral");
            Console.WriteLine("4. Exibir informações de um aluno");
            Console.WriteLine("5. Sair");

            Student[] students = new Student[5];
            int number_of_students = 0;
            string opcao = Console.ReadLine();
            bool continueActive = true; 

            while(continueActive){
                switch(opcao){
                    case "1":
                        if(number_of_students == 5){
                            Console.WriteLine("Número máximo de alunos cadastrados.");
                            break;
                        }
                        students[number_of_students] = new Student();
                        Console.WriteLine("Informe o nome do aluno");
                        students[number_of_students].name = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno");
                        if(int.TryParse(Console.ReadLine(), out int nota)){
                            students[number_of_students].grade = nota;
                        }   else {
                            throw new ArgumentException("Informação digitada não é um inteiro");
                        }
                        number_of_students++;
                        break;
                    case "2":
                        for(int i = 0; i < number_of_students; i++){
                            Console.WriteLine($"Estudante: {students[i].name}");
                        }
                        break;
                    case "3":
                        int average = 0;
                        int total = 0;
                        foreach(var std in students){
                            if(std != null)
                                total = total + std.grade;
                        }
                        average = total/number_of_students;
                        Console.WriteLine($"Média geral da turma: {average}");
                        break;
                    case "4":
                        Console.WriteLine("Informe o nome do aluno: ");
                        string name = Console.ReadLine();
                        int position = -1;
                        for(int i = 0; i < number_of_students; i++){
                            if(students[i].name.Equals(name)){
                                position = i;
                            }
                        }
                        if(position < 0){
                            Console.WriteLine("Estudante não encontrado.");
                        } else {
                            Console.WriteLine($"Estudante: {students[position].name}\nNota: {students[position].grade}");
                        }
                        break;
                    case "5":
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = Console.ReadLine();
            }
        }
    }
}
