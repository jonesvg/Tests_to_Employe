# Tests_to_Employe
A portfolio of tests i made to employers.
CWI TEST (Portuguese)

Criar um método em .NET com a seguinte assinatura:
 
public string ChangeDate(string date, char op, long value);
 
Dado que:
 
date: é uma data em forma de String formatada no padão “dd/MM/yyyy HH24:mi”
op: operação, só poderá aceitar os caracteres ‘+’ e ‘-’
value: valor em minutos que deve ser acrescentado ou decrementado
  
Regras e Restrições:
 
·         Não é permitida a utilização de qualquer classe ou biblioteca não nativa
·         Não é permitida a utilização das classes DateTime e TimeSpan
·         Se o valor for menor que zero, o sinal deve ser ignorado (tratar como positivo)
·         Ignore o fato de fevereiro poder possuir 28 ou 29 dias. Considere-o sempre com 28
·         Ignore a existência de horário de verão
 
Exemplo:
ChangeDate("01/03/2010 23:00", '+', 4000) = "04/03/2010 17:40"

Colocar a classe criada dentro de um namespace com o nome do candidato.
