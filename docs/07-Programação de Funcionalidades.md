# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

Implementação do sistema descrita por meio dos requisitos funcionais e/ou não funcionais. Deve relacionar os requisitos atendidos com os artefatos criados (código fonte), deverão apresentadas as instruções para acesso e verificação da implementação que deve estar funcional no ambiente de hospedagem.

Por exemplo: a tabela a seguir deverá ser preenchida considerando os artefatos desenvolvidos.

|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-01| O sistema deve permitir o usuário se cadastrar e fazer login na plataforma.   | Microsoft.AspNetCore.Identity.Entity.EntityFrameworkCore - Microsoft.AspNetCore.Identity.Entity.UI  | 
|RF-02| O sistema deve validar as informações de login do usuário.  | Microsoft.AspNetCore.Identity.Entity.EntityFrameworkCore - Microsoft.AspNetCore.Identity.Entity.UI |
|RF-03|O usuário deve conseguir alterar informações do seu perfil.  | UsuariosController.cs - Usuario.cs - Create.cshtml - Edit.cshtml - Perfil.cshtml  | 
|RF-04| O usuário terá a possibilidade de dar “likes” ou “pular” os perfis que forem apresentados. |  |
|RF-05|O sistema deve conectar usuários que trocaram “likes”. (Match)  |   | 
|RF-06|No perfil deve ser possível escolher filtros para a busca de usuários. |  |
|RF-07| Usuários que deram match devem conseguir se comunicarem por chat.  |   | 
|RF-08| O sistema deve permitir o usuário avaliar os perfis com quem obteve contato.   | |
|RF-09| O usuário deve conseguir visualizar os perfis dos demais usuários  |  UsuariosController.cs - Usuario.cs - Swipe.cshtml  |

# Instruções de acesso

Não deixe de informar o link onde a aplicação estiver disponível para acesso (por exemplo: https://adota-pet.herokuapp.com/src/index.html).

Se houver usuário de teste, o login e a senha também deverão ser informados aqui (por exemplo: usuário - admin / senha - admin).

O link e o usuário/senha descritos acima são apenas exemplos de como tais informações deverão ser apresentadas.

> **Links Úteis**:
>
> - [Trabalhando com HTML5 Local Storage e JSON](https://www.devmedia.com.br/trabalhando-com-html5-local-storage-e-json/29045)
> - [JSON Tutorial](https://www.w3resource.com/JSON)
> - [JSON Data Set Sample](https://opensource.adobe.com/Spry/samples/data_region/JSONDataSetSample.html)
> - [JSON - Introduction (W3Schools)](https://www.w3schools.com/js/js_json_intro.asp)
> - [JSON Tutorial (TutorialsPoint)](https://www.tutorialspoint.com/json/index.htm)
