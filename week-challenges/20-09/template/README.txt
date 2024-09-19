# Sobre a arquitetura

É bem parecido com a godot, cenas (Scene.cs) são conjutos de objetos (Ojbect.cs). 
Cada Objeto tem seu conjuto de funções built-in que são chamadas automaticamente:
- Create: Toda vez que o jogo começa;
- Update: Todo tick;
- Draw: Todo frame (parecido com o update mas serve pra desenhar coisa na tela);
- Dispose: Todas vez antes do objeto ser deletado da memoria.

Existem 3 tipos de objetos pré-prontos pra você utilizar:
- Sprite: Você carrega a textura e ele desenha na tela pra você (sim, ele é compativel com animações, leia o Player.cs pra ver um exemplo de animação);
- Tileset: Carrega um arquivo de tileset do Tiled com uma textura;
- Tilemap: Carrega um arquivo de mapa do Tiled, precisa de um tileset pra funcionar;
- Tilelayer: Camada do tilemap que você carregou, serve pra alterar a ordem de desenho do jogo (leia Map.cs pra ver um exemplo).

O arquivo Config.cs tem algumas configurações uteis. Escreva 'using static Platformer.Config;' no topo dos seus scripts pra utilizar as variaveis dele.

O arquivo Map.cs inicializa a cena. Tem que mexer nele se for adicionar mais objetos ou camadas de tilemap pra cena.

O arquivo Player.cs é bem basico, é aqui que você vai fazer a magia acontecer. Boa sorte!


# Como construir execultavel
Só rodar 'dotnet build clean'. O dotnet vai baixar as DLLs necessarias pra você automaticamente.
Pra rodar o jogo eu recomendo usar o comando 'dotnet run -v m', ele é mais descritivo.


# Pasta 'Content'
Mapas e sprites estão aqui, tambem tem uns arquivos de som se você quiser um desafio a mais.
PS: pra tocar sons tem que usar a classe 'Sound'.


# Links uteis
(esses dois primeiros são muito uteis, recomendo ter eles abertos no navegador a todo momento)
- Documentação do Raylib:     https://github.com/MrScautHD/Raylib-CSharp/wiki
- Exemplos usando o Raylib:   https://www.raylib.com/examples.html
- Editor de imagens:          https://www.photopea.com/
- Paleta de cores usada:      https://lospec.com/palette-list/hope-diamond


# Dicas
Pra calcular as colisões dentro do raylib, é recomendado usar a classe 'ShapeHelper', ela tem umas funções bem uteis, principalmente a 'CheckCollisionRecs()'
