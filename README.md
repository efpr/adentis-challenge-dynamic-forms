# Desafio
O objetivo deste desafio é testar a capacidade de construir uma página que gere formulários dinâmicos com base em uma configuração externa por Companhia (um arquivo JSON).

A página deverá consistir numa dropdown onde se deverá escolher uma das companhias
existentes e após seleção deverá ser mostrado na página o formulário respetivo.

Após a solução estar terminada, sem quaisquer alterações adicionais ao código, deverá então bastar adicionar novas companhias e os respetivos campos ao ficheiro JSON para que as novas companhias apareçam na dropdown com comportamento idêntico às anteriores (após seleção das mesmas deverá ser mostrado o formulário configurado de forma semelhante ao que já acontecia com as anteriores).

Este projeto deve ser feito com foco em boas práticas de desenvolvimento, de preferência incluindo os princípios de SOLID, design patterns, e separação de responsabilidades.

# Como correr
1. Faça o download do repositório: `git clone git@github.com:efpr/adentis-challenge-dynamic-forms.git`.
2. Navegar para o projeto.
3. Executar o comando: `docker-compose up --build -d`.
4. O projeto não contém implementação de CORS ou de SSL. Por esse motivo, é aconselhável abri-lo em um navegador Chromium, sendo o Edge a melhor opção.
   - Para executar noutros browsers é necessário ativar pedidos http.
5. O website pode ser encontrado no seguinte endereço: `http://localhost:3000`.
6. Também está disponível uma página Swagger onde é possível criar novas companhias: `http:localhost:8080/swagger`.

# Solução

## Backend
Para este desafio, optei por utilizar "Clean Architecture" com base na [webinar da .NET](https://youtu.be/yF9SwL0p0Y0?si=nqHGVhqm7QQXLU9F). O fato de o desafio esclarecer que a solução deve ter como foco os princípios SOLID faz com que a Clean Architecture seja a melhor escolha em comparação com a solução comum "N-Layer". Além de ser uma abordagem mais alinhada aos princípios SOLID, a Clean Architecture oferece uma solução mais robusta, especialmente considerando que o desafio indica a possibilidade de geração dinâmica de formulários, o que facilita futuras alterações. Para a interação dos uses cases com os controllers utilizei o "mediator pattern" pois permite uma melhor separação de conceitos.

## Fronend
Ryan Dahl, o criador do Node.js, lançou recentemente a nova versão do Deno, o Deno 2. Com um pouco de curiosidade, acabei por não resistir a experimenta-lo. Assim sendo, o frontend foi desenvolvido em React Vite, utilizando o Deno. Para complementar o layout, recorri ao Bootstrap para facilitar o design dos componentes.