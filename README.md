# JetBoxer2D

**JetBox2D**  contém tanto um motor 2D leve para criar jogos em C#, baseado no framework Monogame (https://github.com/MonoGame/MonoGame), quanto um exemplo de jogo chamado JetBoxer que demonstra o seu uso.


## O motor JetBox2D contém o seguinte: ##

- **Sistema de Entrada Dinâmica** que suporta entrada concorrente tanto de gamepad, teclado e mouse, via um único InputManager com métodos como GetButtonDown(InputAction). Cada InputAction (por exemplo, ShootRight) é criada de forma a que possa ser mapeada para o gatilho direito do gamepad, botão A do gamepad, tecla de espaço do teclado e clique direito do mouse ao mesmo tempo, o que significa que qualquer um desses tipos de entrada irá acionar a InputAction ShootRight.

- **Sistema de Animação**, que pode transformar uma única folha de sprites em uma animação em loop (ou não), com velocidade ajustável, tamanho e métodos para obter informações úteis sobre a animação atual, como seu NormalizedTime e se terminou.

- **Sistema de Partículas**, que pode ser utilizado para criar efeitos de jogo personalizados como explosões ou rastros de fogo.

- **Colisores Físicos**, para detectar colisões entre os objetos do jogo.

- **Objetos e Estados**, que são necessários para criar os sistemas subjacentes do jogo (por exemplo, transição do Estado de Splash para o Estado de Jogabilidade).

- **Extensões Personalizadas**, que podem ser utilizadas para facilitar o desenvolvimento durante a produção do motor do jogo. Por exemplo, uma classe de envoltório para a entrada do mouse do Monogame, chamada MouseInput, é usada pelo Sistema de Entrada para auxiliar no tratamento da entrada do mouse.
