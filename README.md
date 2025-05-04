# Sistema de Gerenciamento de Funcionários (C#)

1. Descrição do Projeto
Este projeto tem como objetivo o desenvolvimento de um sistema de gerenciamento de funcionários utilizando a linguagem de programação C#, com foco nos conceitos de Programação Orientada a Objetos (POO): herança, polimorfismo, métodos virtuais e abstratos.

O sistema é executado via console e permite interações diretas com o usuário através de menus interativos.

✅ 2. Funcionalidades
O sistema implementa as seguintes funcionalidades:

🔹 2.1 Cadastro de Funcionários
Permite cadastrar diferentes tipos de funcionários:

Gerente

Desenvolvedor

Estagiário

Dados coletados:

Nome

Idade

Cargo

Salário base

Forma de pagamento (Pix, Débito em conta, Dinheiro)

Método de entrega (Automático ou Manual)

Bônus (caso seja Gerente)

Horas extras e valor por hora (caso seja Desenvolvedor)

🔹 2.2 Consulta de Funcionários
Exibe uma lista numerada com os funcionários cadastrados.

Mostra: Nome, Cargo e Salário base.

🔹 2.3 Cálculo de Salário e Impostos
Calcula o salário total de cada funcionário com base no cargo:

Gerente: salário base + bônus

Desenvolvedor: salário base + (horas extras × valor da hora)

Estagiário: apenas salário base

Aplica as alíquotas de imposto:

Gerente: 27,5%

Desenvolvedor: 10%

Estagiário: Isento

Mostra salário bruto, imposto e salário líquido.

🔹 2.4 Entrega de Pagamentos
Informa como o funcionário receberá o salário:

Valor líquido

Forma de pagamento

Método de entrega

🔹 2.5 Exclusão de Funcionário
Lista todos os funcionários cadastrados.

Permite selecionar e excluir um cadastro pelo número da lista.

🔹 2.6 Encerrar Sistema
Finaliza o programa de forma segura.

🏗️ 3. Estrutura do Código
🔸 Classes Utilizadas
Funcionario (classe abstrata)
Contém atributos comuns e métodos abstratos/virtuais:

CalcularSalario() (abstrato)

CalcularImpostos() (virtual)

EntregarPagamento() (virtual)

Gerente (herda Funcionario)

Desenvolvedor (herda Funcionario)

Estagiario (herda Funcionario)

🔸 Principais Conceitos de POO aplicados:
Herança: Classes derivadas herdam da base Funcionario.

Polimorfismo: Uso de métodos sobrescritos de forma dinâmica.

Métodos Abstratos: Forçam a implementação de lógica específica nas subclasses.

Métodos Virtuais: Permitem comportamento padrão que pode ser modificado.

💻 4. Como Utilizar o Sistema
Execute o programa via terminal com dotnet run.

Um menu será exibido com as opções disponíveis.

O usuário digita a opção desejada e segue os passos indicados.

As opções permitem cadastrar, consultar, calcular, entregar, excluir e sair.

⚠️ 5. Dificuldades Encontradas
Gerenciamento de herança correta:
Garantir que os métodos CalcularSalario fossem implementados corretamente em todas as subclasses exigiu atenção especial à lógica de cada cargo.

Cálculo de salário com variações:
O tratamento das regras específicas de bônus e horas extras trouxe complexidade ao sistema.

Design de menu interativo:
Tornar o sistema amigável e funcional no console exigiu testes para tratar entradas inválidas e evitar falhas.

Exclusão de funcionário:
Implementar a exclusão mantendo os índices da lista atualizados e evitando erros de acesso inválido foi um desafio adicional.

Manter o código compreensível:
Buscou-se manter uma estrutura clara e com comentários, mas permitindo também um certo “erro humano” intencional para não parecer um sistema perfeito demais.

📎 6. Conclusão
Este projeto cumpriu os requisitos propostos, permitindo o gerenciamento de funcionários de maneira interativa no console, utilizando os principais pilares da POO em C#. Além de reforçar conceitos teóricos, o sistema também simula situações reais de lógica empresarial, como gestão de pagamentos e tributações por categoria profissional.

