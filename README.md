# AR Cajicá - Aplicación de Realidad Aumentada

**AR Cajicá** es una herramienta digital de visualización interactiva desarrollada para el municipio de Cajicá, Cundinamarca. Utiliza tecnología de **Realidad Aumentada (RA)** para permitir a los usuarios conocer detalladamente las esculturas que componen el **"Sendero del Arte"**, facilitando el acceso virtual a obras que suelen estar en zonas restringidas o de difícil alcance.

---

## 📺 Demostración en Video
[![Ver Demostración de AR Cajicá](https://img.youtube.com/vi/zBFypB8OiU0/0.jpg)](https://www.youtube.com/shorts/zBFypB8OiU0)

> [!TIP]
> [cite_start]Haz clic en la imagen de arriba para ver la demostración del aplicativo en YouTube Shorts. [cite: 1114, 1321]

---

<p align="center">
  <video src="ARCajicaPrueba.mp4" width="800"></video>
</p>

---

## 🚀 Características Principales
* **Visualización Inmersiva:** Modelos 3D detallados de los monumentos del Sendero del Arte.
* **Interactividad Táctil:** Los usuarios pueden escalar, rotar y mover los monumentos en su entorno físico.
* **Información Técnica:** Cada obra incluye detalles sobre el artista, peso y dimensiones.
* **Captura y Compartición:** Incluye un sistema para tomar capturas de pantalla y compartirlas directamente a través de redes sociales.

## 🛠️ Stack Tecnológico
* **Motor de Desarrollo:** Unity 2022.3.21f1.
* **Lenguaje de Programación:** C#.
* **SDK de Realidad Aumentada:** Google ARCore 1.9 o superior.
* **Modelado y Texturizado:**
  * **Autodesk Maya:** Creación de mallas y mapas UV.
  * **Adobe Substance Painter:** Texturizado realista de las obras.
* **Plugins Clave:**
  * **AR Foundation:** Gestión de la sesión de RA y detección de planos.
  * **DOTween:** Animaciones fluidas de la interfaz de usuario.
  * **NativeShare:** Implementación de la funcionalidad de compartir archivos.

## 🏗️ Arquitectura de la Aplicación
El desarrollo se basa en un sistema de gestores (*Managers*) que controlan la lógica del proyecto:
* **`ARInteractionManager`**: Controla el despliegue de modelos y las transformaciones (escala, rotación, posición).
* **`DataManager`**: Gestiona la carga de información desde `ScriptableObjects` para poblar el inventario.
* **`InfoPanelManager`**: Despliega dinámicamente los datos técnicos de cada escultura.
* **`UIManager`**: Maneja las transiciones entre el menú principal, inventario y modo RA.
* **`GameManager`**: Centraliza los eventos y asegura una instancia única mediante el patrón Singleton.

## 📱 Requisitos y Compatibilidad
* **Sistema Operativo:** Android 9.0 (Pie) o superior.
* **Librerías:** Servicios de Google Play para RA (ARCore) instalados.
* **Hardware:** Dispositivos compatibles con la API de profundidad de ARCore (ej. Google Pixel, Samsung Galaxy serie S/A, Xiaomi Redmi Note).

---
Desarrollado como proyecto de grado para el programa de **Ingeniería Multimedia** de la Universidad Militar Nueva Granada.
