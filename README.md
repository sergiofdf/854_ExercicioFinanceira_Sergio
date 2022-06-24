# 854_ExercicioFinanceira_Sergio

Exerc�cio do m�dulo 1 de POO do curso do programa Top Coders.

>Professora �ngela Heredia

--- 

## Enunciado


1) Uma Financeira possui clientes pessoa f�sica e pessoa jur�dica. A Financeira precisa de um sistema para gerenciar os contratos de financiamento com seus clientes. Os contratos possuem n�mero, nome do contratante, valor do contrato e prazo.

Crie uma classe contrato com os atributos idContrato ( Guid ), contratante ( string ), valor ( decimal ) e prazo ( int ).

1.1. ) Heran�a - Os contratos podem ser contrato de pessoa f�sica e contrato de pessoa jur�dica. Os contratos de pessoa f�sica tamb�m tem o CPF  e a data de nascimento do contratante. Os contratos de pessoa jur�dica possuem o CNPJ e a inscri��o estadual da empresa contratante. Usando o conceito de heran�a, crie a classe ContratoPessoaFisica herdando da classe Contrato e com os atributos adicionais do Contrato Pessoa F�sica. Em seguida, crie a classe ContratoPessoaJuridica herdando da classe Contrato e com os atributos adicionais do Contrato Pessoa Jur�dica.
Implemente as classes necess�rias para representar os diferentes contratos da Financeira.

1.2. ) Polimorfismo - O valor da presta��o de um contrato � calculado por um m�todo calcularPresta��o(), como sendo o valor do contrato dividido pelo prazo. Este m�todo calcularPresta��o() existe para todos os Contratos. Entretanto, para os contratos de pessoa jur�dica existe um adicional de 3 reais no valor de cada presta��o e para os contratos de pessoa f�sica o valor da presta��o tamb�m tem um adicional no valor da presta��o que deve ser calculado de acordo com a idade do contratante:
idade <= 30 tem adicional de 1,00
idade <= 40 tem adicional de 2,00
idade <= 50 tem adicional de 3,00
idade > 50 tem adicional de 4,00
Implemente o m�todo calcularPrestacao() na(s) classe(s) necess�rias.
1.3 ) Mais m�todos - Todos os contratos devem ter um m�todo exibirInfo() ( que n�o retorna valor e que n�o tem par�metros ) para informar o valor do contrato, o prazo e o valor da presta��o. Al�m disso, os contratos de pessoa f�sica devem informar tamb�m a idade do contratante.

---

## Como executar o programa
- Clonar o reposit�rio em uma pasta local:
    `git clone https://github.com/sergiofdf/854_ExercicioFinanceira_Sergio.git`
  
- Abra a solu��o do projeto com o visual studio, arquivo `854Prova_SergioDias.sln`.

- Execute o projeto com `CTRL + F5`