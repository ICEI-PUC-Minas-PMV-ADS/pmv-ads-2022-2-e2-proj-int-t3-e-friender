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
 **Gabriela Cândido** **35** anos Recepcionista, busca migrar para programação e frequenta cursos online sobre o assunto.|Ampliar renda salarial, Independência financeira, Morar em outro país, Mudar de profissão|Problemas familiares, Insegurança pessoal|Ler livros, Ir à academia, Praticar yoga, Jogar no celular, Candy Crush, Summoners War, Clash Royalle




















Enumere e detalhe as personas da sua solução. Para tanto, baseie-se tanto nos documentos disponibilizados na disciplina e/ou nos seguintes links:

> **Links Úteis**:
> - [Rock Content](https://rockcontent.com/blog/personas/)
> - [Hotmart](https://blog.hotmart.com/pt-br/como-criar-persona-negocio/)
> - [O que é persona?](https://resultadosdigitais.com.br/blog/persona-o-que-e/)
> - [Persona x Público-alvo](https://flammo.com.br/blog/persona-e-publico-alvo-qual-a-diferenca/)
> - [Mapa de Empatia](https://resultadosdigitais.com.br/blog/mapa-da-empatia/)
> - [Mapa de Stalkeholders](https://www.racecomunicacao.com.br/blog/como-fazer-o-mapeamento-de-stakeholders/)
>
Lembre-se que você deve ser enumerar e descrever precisamente e personalizada todos os clientes ideais que sua solução almeja.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Usuário do sistema  | Registrar minhas tarefas           | Não esquecer de fazê-las               |
|Administrador       | Alterar permissões                 | Permitir que possam administrar contas |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir que o usuário cadastre tarefas | ALTA | 
|RF-002| Emitir um relatório de tarefas no mês   | MÉDIA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser responsivo para rodar em um dispositivos móvel | MÉDIA | 
|RNF-002| Deve processar requisições do usuário em no máximo 3s |  BAIXA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

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

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
