# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

As ***personas*** que ilustram nosso público-alvo são mostradas nas tabelas a seguir: 
| `USUÁRIO` |`MOTIVAÇÕES`| `FRUSTRAÇÕES` | `HOBBIES / JOGOS / APLICATIVOS` |
|----------------------|--------------------|--------------------|------------------------|
|![SemMensagensDeErros](https://user-images.githubusercontent.com/100388026/188516668-8a3b2ab4-a799-4d6d-8d8a-7b1edd0332db.png)
**Gabriel Toledo** **30** anos, Estudante, busca se tornar um engenheiro e seguir a carreira do pai. | Ler livros, Assistir seriados/filmes,Jogar no computador|Não poder comprar o que quer, Pouco tempo livre, Falta de crescimento profissional|Ler livros, Assistir seriados/filmes, Jogar no computador,Counter Strike, Valorant, Call of Duty|
|||||
| ![SemMensagensDeErros](https://user-images.githubusercontent.com/100388026/188517763-8b38fbd8-b895-40b6-9445-8b502df909a7.png)
 **Rafael Lange** **23** anos, Cadeirante e com dificuldade de fala, ocupa um cargo PCD em uma grande empresa, mas almeja ir para área de Design e por isso faz cursos online.|Mudar de área, Ajudar a família, Sair com os amigos, Ser aceito|Sofre preconceito por conta da sua condição, Ter poucos amigos, Vida amorosa instável| Jogar jogos no computador, Assistir streams de jogos,Assistir séries/filmes.
 |||||
| ![SemMensagensDeErros](https://user-images.githubusercontent.com/100388026/188518367-be31ef98-9519-4e53-ae34-a3d3971a4a7b.png)
 **Aline Fukushima** **19** Estudante, busca ser uma desenvolvedora de software.|Ingressar no mercado de desenvolvimento, Comprar um novo computador, Sair com os amigos|Não ter estabilidade financeira, Não ter experiência de trabalho, Pouco poder de compra|Jogar jogos online, Assistir streams de jogos, Ler notícias de e-sports, Pokémon TCG, Fortnite, Minecraft, League of Legends.
  |||||
| ![SemMensagensDeErros](https://user-images.githubusercontent.com/100388026/188518773-c7167451-3d91-4a68-85f1-5cbcc767a5b7.png)
 **Joana Alencar** **28** Auxiliar de produção, busca mudar de área após nova formação acadêmica.|Ingressar no mercado de programação,	Ampliar renda salarial,	Independência financeira, Conhecer novos jogos|Instabilidade financeira, Pouco poder de compra, Dificuldade de socialização|Jogar videogame, Navegar pelas redes sociais, Leitura Geek, Stardew Valley, The Sims, Fall Guys.
|||||
| ![SemMensagensDeErros](https://user-images.githubusercontent.com/100388026/188519162-c06372d1-7ba8-4d0d-8b32-15f046ba8895.png)
 **Gabriela Cândido** **35** anos Recepcionista, busca migrar para programação e frequenta cursos online sobre o assunto.|Ampliar renda salarial, Independência financeira, Morar em outro país, Mudar de profissão|Problemas familiares, Insegurança pessoal|Ler livros, Ir à academia, Praticar yoga, Jogar no celular, Candy Crush, Summoners War, Clash Royalle.
 |||||
| ![SemMensagensDeErros](https://user-images.githubusercontent.com/100388026/188519572-4bfca75a-6303-452d-9665-98fddf884164.png)
 **Rogério Miranda** **46** anos, Professor, busca aperfeiçoamento na área a partir de cursos online.|Ampliar círculo social, Fazer Doutorado, Aprender novas tecnologias|Dificuldade com relacionamento amoroso, Sente-se ultrapassado tecnologicamente|Ler livros, Praticar Artes Marciais, Escrever, Jogar jogos que estimulem o raciocínio, Xadrez, Sudoku, Poker






## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Gabriel Toledo   | Sair com os amigos de curso.           | Melhorar o círculo social e estreitar relações.|
|Rafael Lange  |Ser aceito pelas pessoas, independente da sua condição.|Ter mais autoestima e melhorar o relacionamento com as pessoas.  |
|Aline Fukushima  |Conhecer pessoas que estudem na mesma área a qual ela almeja ingressar  | Angariar contatos para facilitar seu ingresso no mercado de trabalho |
|Joana Alencar      | Conhecer novos jogos.  | Ter novas possibilidades de distração quando estiver em casa. |
|Gabriela Cândido       |Conhecer pessoas que moraram fora do país.  | Ouvir conselhos e angariar opiniões a respeito de morar fora do país.|
|Rogério Miranda      | Aprender novas tecnologias.      | Melhorar a autoestima e ampliar o círculo social.  |






## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais
A seguir estão listados todos os requisitos funcionais do projeto e as prioridades de execução do mesmo: 

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-01| O sistema deve permitir o usuário se cadastrar e fazer login na plataforma.   | ALTA  | 
|RF-02| O sistema deve validar as informações de login do usuário.  | ALTA |
|RF-03|O usuário deve conseguir alterar informações do seu perfil.  | MÉDIA  | 
|RF-04| O usuário terá a possibilidade de dar “likes” ou “pular” os perfis que forem apresentados. | ALTA |
|RF-05|O sistema deve conectar usuários que trocaram “likes”. (Match)  | ALTA  | 
|RF-06|No perfil deve ser possível escolher filtros para a busca de usuários. | MÉDIA |
|RF-07| Usuários que deram match devem conseguir se comunicarem por chat.  | ALTA  | 
|RF-08| O sistema deve permitir o usuário avaliar os perfis com quem obteve contato.   | BAIXA |
|RF-09| O usuário deve conseguir visualizar os perfis dos demais usuários  | ALTA |




### Requisitos não Funcionais
Os requisitos não funcionais do projeto estão listados a seguir com suas respectivas prioridades:

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-01  | O sistema deve estar acessível publicamente na internet. | ALTA | 
|RNF-02  | O sistema deve ser responsivo em operações através de dispositivos mobiles.  | MÉDIA | 
|RNF-03  | O sistema deve ser compatível com os principais navegadores do mercado (Google Chrome, Firefox, Microsoft Edge)  | ALTA | 
|RNF-04  | O sistema deve funcionar 24h por dia, todos os dias da semana. | ALTA |
|RNF-05  | Dados cadastrais serão privados e disponíveis apenas para a equipe de desenvolvimento e o próprio usuário.  | ALTA | 
|RNF-06  | O projeto será desenvolvido na linguagem C# | ALTA |





## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

A fim de detalhar os requisitos funcionais do sistema, elaborou-se um diagrama de caso de uso, elucidando os relacionamentos que os atores podem ter com produto desenvolvido: 
![Diagrama de caso de uso](https://user-images.githubusercontent.com/63081926/189237586-e881762f-b348-4e7c-81ed-325606dc49cd.PNG)


As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
