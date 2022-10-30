# Registro de Testes de Software

## 1 - Introdução

Este documento descreve os requisitos a testar, os  tipos de testes definidos para cada iteração, os recursos de hardware e software a serem empregados e os resultados de cada teste. 

## 2 - Casos de Teste
Esta seção contem os casos de teste referentes aos casos de uso e não funcionais identificados ao longo do desenvolvimento do projeto.

### Casos de uso:

| **Caso de Teste** 	| **RF-01 – Cadastrar Perfil** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01 - A aplicação deve apresentar, na página principal, a funcionalidade de cadastro de usuários para que esses consigam criar e gerenciar seu perfil. |
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o endereço da aplicação <br> - Clicar em "Criar conta" <br> - Preencher os campos obrigatórios (e-mail, nome, sobrenome, celular, CPF, senha, confirmação de senha) <br> - Aceitar os termos de uso <br> - Clicar em "Registrar" |
|Critério de Êxito | - Realizar o Cadastro com Sucesso. |
|  	|  	|
|Resultado| - https://user-images.githubusercontent.com/103212087/198860980-f20e6026-fee6-4e6b-8370-b735a8138211.mp4|
|  	|  	|

| **Caso de Teste** 	| **CT-02 – Validar informações de Login** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-02 - O sistema deve validar as informações de login do usuário. |
| Objetivo do Teste 	| Verificar se o usuário consegue se autenticar na aplicação. |
| Passos 	| - Acessar o endereço da aplicação <br> - Clicar em "Entrar" <br> - Preencher os campos obrigatórios (e-mail, senha) <br> - Clicar em "Entrar" |
|Critério de Êxito | - Autenticação realizado com sucesso. Usuario redirecionado para a página inicial de usuário. |
|  	|  	|
|Resultado| - https://user-images.githubusercontent.com/103212087/198860980-f20e6026-fee6-4e6b-8370-b735a8138211.mp4|
|  	|  	|

| **Caso de Teste** 	| **CT-03 – Alterar informações de Perfil** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-03 - O usuário deve conseguir alterar informações do seu perfil. |
| Objetivo do Teste 	| Verificar se o usuário consegue alterar informações de perfil. |
| Passos 	| - Realizar a autenticação na aplicação <br> - Clicar em "Perfil" <br> - Alterar informações de Perfil (nome, nickname, curso, discord, idade, genero) |
|Critério de Êxito | - Dados atualizados no sistema com sucesso. |
|  	|  	|
|Resultado| - https://user-images.githubusercontent.com/103212087/198861095-2099674e-5663-4a61-9c67-f8a30319e6ad.mp4|
|  	|  	|

| **Caso de Teste** 	| **CT-04 – Dar like em um usuario** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-04 - O usuário terá a possibilidade de dar “likes” ou “pular” os perfis que forem apresentados. |
| Objetivo do Teste 	| Verificar se o usuário é capaz de dar like em outro usuário que tenha aparecido na tela de forma aleatória. |
| Passos 	| - Realizar a autenticação na aplicação <br> - Dar like em usuario que apareça na tela, clicando no icone de "checkmark", localizado a direita da imagem do usuario que será curtido. |
|Critério de Êxito | - Será registrado o like no sistema e a imagem de outro usuario para avaliação irá substituir a imagem do usuário que levou o like. |
|  	|  	|

| **Caso de Teste** 	| **CT-04B – Pular um usuario** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-04B - A aplicação deve apresentar, na página principal, a funcionalidade de cadastro de usuários para que esses consigam criar e gerenciar seu perfil. |
| Objetivo do Teste 	| Verificar se o usuário consegue pular um determinado usuário que tenha aparecido na tela de forma aleátoria. |
| Passos 	| - Realizar a autenticação na aplicação <br> - Pular um usuario que apareça na tela, clicando no icone de "x", localizado a esquerda da imagem do usuario que será curtido. |
|Critério de Êxito | - Não será registrado nenhum like no sistema e a imagem de outro usúario irá substituir a imagem do usuário que não recebeu like. |
|  	|  	|

| **Caso de Teste** 	| **CT-05 – Conectar com outro usuario que trocou like** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-05 - O sistema deve conectar usuários que trocaram “likes”. (Match) |
| Objetivo do Teste 	| Verificar se ocorre a conexão com outro usuário que tenha trocado like. |
| Passos 	| - Realizar a autenticação na aplicação com uma conta de usuário "a" <br> - Dar like em um usuário 'b'. <br> - Sair da aplicação clicando no botão 'Sair' na barra de nevegação. <br> - Realizar autenticação na aplicação com as credênciais do usuário 'b'. <br> - Dar like no usuário 'a' quando o mesmo aparecer na tela'. |
|Critério de Êxito | - O usuário 'b' será notificado do 'match' com o usuário 'a' e o contato do mesmo ficara disponivel na lista de matches, localizada no canto esquerdo da aplicação. |
|  	|  	|

| **Caso de Teste** 	| **CT-06 – Utilizar perfil para realizar filtro de usuarios que poderão aparecer na tela** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-06 - No perfil deve ser possível escolher filtros para a busca de usuários. |
| Objetivo do Teste 	| Verificar se o sistema de filtro de preferências por usuários funciona corretamente. |
| Passos 	| - Realizar a autenticação na aplicação com uma conta de usuário "a" <br> - Clicar em "Perfil" na barra de navegação superior. <br> - Utilizar o form de filtro para configurar as preferências quanto ao aparecimento de outros usuários (games preferidos, idade, genêro). <br> - Clocar em 'Aplicar'." |
|Critério de Êxito | - Novos usuários serão mostrados na tela de acordo com as preferências configuaradas pelo usuário. |
|  	|  	|

| **Caso de Teste** 	| **CT-07 – Comunicar por chat com outro usuario que tenha dado Match** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-07 - Usuários que deram match devem conseguir se comunicarem por chat. |
| Objetivo do Teste 	| Verificar se o sistema de Chat para troca de mensagem com outros usuários com quem tenha dado Match funciona corretamente. |
| Passos 	| - Realizar a autenticação na aplicação com uma conta de usuário "a" <br> - Clicar em "Conversar" na barra de navegação superior. <br> - Clicar em um usuário com quem tenha ocorrido match para abrir a janela de chat. <br> - Enviar mensagem para o usuário 'match'." |
|Critério de Êxito | - A mensagem será enviado com sucesso para o usuário "match". |
|  	|  	|

| **Caso de Teste** 	| **CT-08 – Avaliar o Perfil de outro usuario com quem tenha tido contato** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-08 - O sistema deve permitir o usuário avaliar os perfis com quem obteve contato. |
| Objetivo do Teste 	| Verificar se o usuário consegue avaliar o perfil de outros usuários com quem tenha dado match. |
| Passos 	| - Realizar a autenticação na aplicação. <br> - Clicar em um usuário com quem tenha ocorrido match, na lista de matches localizada na lateral esquerda da aplicação. <br> - Após a abertura do perfil de usuário, clicar no botão 'Avaliar', localizado no canto inferior direito da aplicação <br> - Avaliar o Perfil do usuário, dando uma nota que poderá ir de até 01 (uma) a 05 (cinco) estrelas. |
|Critério de Êxito | - A avaliação será contabilizada com sucesso. |
|  	|  	|

| **Caso de Teste** 	| **CT-09 – Visualizar o Perfil de outros usuarios** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-09 - O usuário deve conseguir visualizar os perfis dos demais usuários |
| Objetivo do Teste 	| Verificar se é possível visualizar perfis de outros usuários que apareçam na tela. |
| Passos 	| - Realizar a autenticação na aplicação. <br> - Clicar em um usuário com quem tenha ocorrido match, na lista de matches localizada na lateral esquerda da aplicação. <br> |
|Critério de Êxito | - Será exibida o Perfil do Match. |
|  	|  	|

### Requisitos não-funcionais:

| **Caso de Teste** 	| **CT-10 – Visualizar o Perfil de outros usuarios** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RNF-01 - O sistema deve estar acessível publicamente na internet. |
| Objetivo do Teste 	| Verificar se a aplicação está disponivel para ser acessda na internet. |
| Passos 	| - Abri um browser (Chrome, Edge, Firefox, etc) em um sistema conectado a internet  <br> - Digitar o endereço da aplicação na barra de endereços. <br> |
|Critério de Êxito | - A página inicial da aplicação será exibida. |
|  	|  	|

| **Caso de Teste** 	| **CT-11 – Responsividade do sistema** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RNF-02 - O sistema deve ser responsivo em operações através de dispositivos mobiles.. |
| Objetivo do Teste 	| Verificar se o sistema está responsivel para dispositivos moveis. |
| Passos 	| - Abri um browser (Chrome, Edge, Firefox, etc) em um sistema conectado a internet  <br> em um dispositivo movel - Digitar o endereço da aplicação na barra de endereços. <br> |
|Critério de Êxito | - A página inicial da aplicação será exibida de forma adaptada e compativel com a viewport do dispositivo movél. |
|  	|  	|

| **Caso de Teste** 	| **CT-12 – Compatibilidade do sistema com os principais navegadores do mercado** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RNF-03 - O sistema deve ser compatível com os principais navegadores do mercado (Google Chrome, Firefox, Microsoft Edge) |
| Objetivo do Teste 	| Verificar se o sistema está responsivel para dispositivos moveis. |
| Passos 	| - Abri um browser (Chrome, Edge, Firefox, Brave, Opera) em um sistema conectado a internet  <br> em um dispositivo movel - Digitar o endereço da aplicação na barra de endereços. <br> - Repetir a operação para os outros browsers listados. |
|Critério de Êxito | - Em cada acesso de cada browser a página inicial da aplicação será exibida. |
|  	|  	|

| **Caso de Teste** 	| **CT-13 – Compatibilidade do sistema com os principais navegadores do mercado** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RNF-04 - O sistema deve funcionar 24h por dia, todos os dias da semana. |
| Objetivo do Teste 	| Verificar a disponibilidade do sistema, que deve ser de 24h durante todos os dias da semana. |
| Passos 	| - Configurar um serviço de monitoramento de aplicações web (UpTimeRobot ou similar) para realizar checagens de resposta na aplicação em um intervalo de tempo de 1 em 1 hora. |
|Critério de Êxito | - O relatorio de monitoramento do serviço deverá indicar que a aplicação respondeu em todas as chamadas solicitadas. |
|  	|  	|

