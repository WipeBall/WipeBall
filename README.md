# WipeBall

WipeBall es un juego de plataformas en 3D desarrollado en Unity donde controlas una bola física a través de desafiantes recorridos llenos de obstáculos.

## Características Principales

*   **Físicas Realistas**: Controla el impulso, salto y rebote de la bola para superar los niveles.
*   **Obstáculos Dinámicos**: Enfréntate a diversos peligros como:
    *   **Golpeadores**: Trampolines que te lanzan por los aires al contacto.
    *   **Péndulos y Rotadores**: Objetos móviles que intentarán tirarte al vacío.
    *   **Vacío**: Si caes por debajo del límite del nivel, reaparecerás en el último punto seguro.
*   **Sistema de Checkpoints**: Mecánica de guardado automático al tocar puntos de control (`GameManager`).
*   **Competitividad**: 
    *   **Cronómetro**: Tiempo en tiempo real.
    *   **Tabla de Récords**: Guarda tus 5 mejores tiempos localmente.
*   **Interfaz (HUD)**: Visualización clara del tiempo y estado del juego.

## Controles

*   **WASD** o **Flechas de Dirección**: Mover la bola.
*   **Barra Espaciadora**: Saltar (Sistema de detección de suelo `isGrounded` para evitar saltos infinitos).
*   **Ratón**: Control de cámara (OrbitCamera).

## Cómo Jugar

1.  Abre el proyecto con **Unity Hub** (Versión compatible con Unity 6/2023+ recomendada).
2.  Carga la escena principal del juego.
3.  Pulsa `Play` en el editor.
4.  Llega a la zona de **Meta** lo más rápido posible sin caer al vacío.

## Detalles Técnicos y Scripts

### Arquitectura General
El núcleo del juego es el `GameManager`, encargado de gestionar el estado global, principalmente el **Respawn** del jugador.
*   **GameManager.cs**: Supervisa la posición vertical del jugador. Si cae por debajo de un umbral (`y < -10`), invoca `Respawn()`, devolviendo al jugador al último `Checkpoint` activo y reseteando sus velocidades lineales y angulares para evitar inercia indeseada.

### Controlador del Jugador
La movilidad se basa en físicas de Unity (`Rigidbody`), evitando traslaciones directas para una sensación más orgánica.
*   **PlayerController.cs**:
    *   **Movimiento**: Aplica fuerzas (`AddForce`) relativas a la dirección de la cámara (`cameraTransform.forward`). Normaliza los vectores para evitar mayor velocidad en diagonales.
    *   **Salto**: Utiliza un impulso instantáneo (`ForceMode.Impulse`). Implementa un booleano `isGrounded` que se activa mediante `OnCollisionEnter` con etiquetas "Suelo", previniendo saltos en el aire.
*   **OrbitCamera.cs**:
    *   Sigue un `target` (el jugador) manteniendo una distancia constante.
    *   Calcula la rotación basándose en el input del ratón (`Mouse X`/`Mouse Y`) y usa trigonometría esférica simplificada con `Quaternion.Euler` para orbitar suavemente.

### Mecánicas del Entorno
Los obstáculos heredan de `MonoBehaviour` y utilizan funciones matemáticas para sus movimientos cíclicos.
*   **Pendulo.cs**: Modifica la rotación en el eje Z usando una función seno (`Mathf.Sin`) dependiente del tiempo, creando un movimiento armónico simple.
*   **Oscillator.cs**: Mueve el objeto verticalmente usando `Mathf.PingPong`, generando un ciclo de subida y bajada constante.
*   **Rotador.cs** (`Rotator`): Aplica una rotación constante en el eje Y (`transform.Rotate`).

#### Interacciones
*   **Golpeador.cs**: Detecta colisiones con `OnTriggerEnter`. Al impactar con el jugador, anula su velocidad actual y aplica una fuerza explosiva en dirección opuesta al centro del golpeador.
*   **WaterTrigger.cs**: Trigger de zona de muerte que invoca directamente `GameManager.Respawn()`.
*   **Checkpoint.cs**: Al ser atravesado, actualiza la propiedad `spawnPoint` del `GameManager`.

### Sistema de UI y Gestión
*   **HUD.cs**: Calcula el tiempo transcurrido en cada frame (`Time.deltaTime`) y lo formatea a minutos, segundos y milisegundos para su visualización en un `TextMeshProUGUI`.
*   **SistemaPausa.cs**: Alterna `Time.timeScale` entre 0 (pausa) y 1 (juego). También gestiona la visibilidad y bloqueo del cursor.
*   **TablaRecords.cs**: Utiliza `PlayerPrefs` para persistencia de datos local, almacenando y recuperando los 5 mejores tiempos.
*   **Meta.cs**: Gestiona la condición de victoria. Detiene el cronómetro del HUD, guarda el récord si aplica, muestra el panel de victoria y libera el cursor.

---
*Proyecto de desarrollo de videojuegos centrado en mecánicas de físicas y control de personaje.*
