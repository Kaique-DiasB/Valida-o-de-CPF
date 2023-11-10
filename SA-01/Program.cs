using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace SA_01
{
	class Program
	{
		/// <summary>
		/// Verificação se todos os digitos do CPF são iguais
		/// </summary>
		/// <param name="VerificarRepetição"> Este método ira receber uma parametro de um vetor char. O qual
		/// verificamos através das posições deste vetor se os valores são iguais à posição inicial exemplo[0]. Caso a posição
		/// for igual a posição 0 é adicinado um valor "++" ao contador. Se o contator bater 11 que o maximo de números
		/// ele retorna um valor booleano.</param>
		/// <returns>Caso verdadeiro o método bool retorna false, caso contrario true.</returns>
		public static bool VerificarRepetição (char[] exemplo){
			
			//Variaveis
			int cont=0;
			for (int i = 0; i <exemplo.Length; i++) {
				if (exemplo[0]==exemplo[i])
				{
					cont++;
				}
			}
			
			//
			if(cont==11){
				return false;
			}
			
			else{
				return true;
			}
		}

		/// <summary>
		/// Calculador do Primeiro Digito do CPF
		/// </summary>
		/// <param name="CalculoSegundoD">Neste método iremos efetuar o cálculo somente do 10º digito do CPF.
		/// Onde multiplicamos todos os 9 dígitos por um peso de 10 a 2 respectivamente. Após a multiplicação
		/// realizamos a soma destes produtos e sua divisão por 11, caso o resultado sejá maior que 2 fazemos
		/// este resultado menos 11 e chegamos ao nosso digito, caso contrario o digito será 0. Após essa verificação
		/// o comparamos com a posição determinada exemplo[9].</param>
		/// <returns>Caso verdadeiro o método bool retorna false, caso contrario true</returns>
		
		public static bool CalculoPrimeiroD (char[] exemplo){
			
			//Declaração de variaveis
			int [] modelo1 = new int [11];
			int soma1=0, resto1=0, posicao10=0, resultado, contador=10;
			
			//Preenchimento do vetor auxiliar e multiplia e soma
			for (int i = 0; i <9; i++) {
				modelo1 [i] = (int)char.GetNumericValue(exemplo[i]);
				soma1+= modelo1[i]*contador;
				contador--;
			}
			
			//Calculo basico do resto da divisão
			resto1=soma1%11;
			posicao10=(int)char.GetNumericValue(exemplo[9]);
			
			//Tratamento do resto da divisão para possível definição do digito
			if (resto1<2) {
				resultado=0;
			}
			else{
				resultado=11-resto1;
				
			}
			
			//Verificação do resto com a posição 10 do CPF, se ambas são iguais
			if(resultado==posicao10){
				return true;
				
			}
			else{
				return false;
				
			}
		}
		
		/// <summary>
		/// Calculador do Segundo Digito do CPF
		/// </summary>
		/// <param name="CalculoSegundoD">Neste método iremos efetuar o cálculo somente do 10º digito do CPF.
		/// Onde multiplicamos todos os 10 dígitos por um peso de 11 a 2 respectivamente. Após a multiplicação
		/// realizamos a soma destes produtos e sua divisão por 11, caso o resultado sejá maior que 2 fazemos
		/// este resultado menos 11 e chegamos ao nosso digito, caso contrario o digito será 0. Após essa verificação
		/// o comparamos com a posição determinada exemplo[10].</param>
		/// <returns>Caso verdadeiro o método bool retorna false, caso contrario true</returns>

		public static bool CalculoSegundoD (char[] exemplo){
			//Declaração de variaveis e vetores
			int [] modelo1 = new int [11];
			int soma2=0, resto2=0, posicao11=0, resultado, contador=11;
			
			//Preenchimento do vetor auxiliar e multiplia e soma
			for (int i = 0; i <10; i++) {
				modelo1 [i] = (int)char.GetNumericValue(exemplo[i]);
				soma2+= modelo1[i]*contador;
				contador--;
			}
			
			//Calculo basico do resto da divisão
			resto2=soma2%11;
			posicao11=(int)char.GetNumericValue(exemplo[10]);
			
			
			//Tratamento do resto da divisão para possível definição do digito
			if (resto2<2) {
				resultado=0;
			}
			else{
				resultado=11-resto2;
				
			}
			
			//Verificação do resto com a posição 10 do CPF, se ambas são iguais
			if(resultado==posicao11){
				return true;
				
			}
			else{
				return false;
				
			}
		}
		
		public static void Main(string[] args)
		{
			//Variaveis
			string CpfPrincipal="";
			char [] CPF = new char[11];
			int op;
			
			
			//Menu principal para seleção das ações
			do
			{
				
				Console.WriteLine("\n-------------------------------------");
				Console.WriteLine("         ESCOLHA UMA OPÇÃO           ");
				Console.WriteLine("-------------------------------------");
				Console.WriteLine("|1 - Inserir um CPF.|\n|2 - Sair.\t    |\n");
				
				op=int.Parse(Console.ReadLine());
				
				switch (op) {
						
						//Primeira opção para ser iniciada a verificação do CPF
					case 1:
						
						//Entrada do CPF em string, utilizei o Replace para remover os pontos e traços da string digitada
						Console.Write("Digite um CPF: ");
						CpfPrincipal=Console.ReadLine().Replace(".","").Replace("-","");
						
						
						/*Para realizar o tratamento da string CpfPrincipal utilizei o Regex que impede o uso de
						caracteres comuns e especiais*/
						
						bool Sonumero = Regex.IsMatch(CpfPrincipal, "^[0-9]+$");
						
						//Condição para verificar se a string se aplica ao Regex e ao tamanho do CPF
						if(Sonumero && CpfPrincipal.Length==11){
							for (int i = 0; i <CpfPrincipal.Length; i++) {
								CPF [i]=CpfPrincipal[i];
							}
							
						}
						
						else if (Sonumero && CpfPrincipal.Length<11){
							Console.WriteLine("Todos os numeros!");
						}
						
						else{
							Console.WriteLine("Digite somente números!");
						}
						
						
						/*Tratamento realizado através de condições para verificarmos se o CPF e valido. Para verificarmos
						se o CPF é valido chamamos a primeira função onde olhamos se os dígitos são iguais, caso for verdadeiro
						entramos em outra condição que recebe os valores das outras duas funções simultaneamente, para validar 
						se o CPF é verdadeiro.*/
						
						if (VerificarRepetição(CPF)==true) {
							
							
							if (CalculoPrimeiroD(CPF)==true && CalculoSegundoD(CPF)==true) {
								Console.WriteLine("CPF Valido!");
							}
							
							else{
								Console.WriteLine("CPF Invalido!");
							}
							
						}
						
						//Fim da verificação se o CPF possui todos os digitos repitidos
						else{
							Console.WriteLine("CPF Invalido!");
						}
						break;
						
						//Segunda opção para sair do console
					case 2:
						
						Console.WriteLine("\n--------------------------------------------------");
						Console.WriteLine("         OPERAÇÃO SE FINALIZARA EM BREVE           ");
						Console.WriteLine("--------------------------------------------------");
						
						//Tempo determinado para ser executado a proxima ação
						Thread.Sleep(3000);
						
						//Fechamento forçado do Console
						Environment.Exit(2);
						
						break;
						
					default:
						
						Console.WriteLine("Tente novamente!");
						break;
				}
				
			}
			while(op!=2);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}