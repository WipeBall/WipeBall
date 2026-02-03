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

---
*Proyecto de desarrollo de videojuegos centrado en mecánicas de físicas y control de personaje.*
