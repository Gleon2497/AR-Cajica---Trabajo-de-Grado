# AR Cajicá - Aplicación de Realidad Aumentada

[cite_start]**AR Cajicá** es una herramienta digital de visualización interactiva desarrollada para el municipio de Cajicá, Cundinamarca[cite: 2994, 2998]. [cite_start]Utiliza tecnología de **Realidad Aumentada (RA)** para permitir a los usuarios conocer detalladamente las esculturas que componen el **"Sendero del Arte"**, facilitando el acceso virtual a obras que suelen estar en zonas restringidas o de difícil alcance[cite: 2997, 2998, 3130, 3140].

---

## 📺 Demostración
> [!IMPORTANT]
> Puedes visualizar el funcionamiento de la aplicación en el siguiente video. (Para que funcione, sube tu video a la carpeta raíz y reemplaza `TU_VIDEO.mp4` con el nombre real del archivo).

<p align="center">
  <video src="TU_VIDEO.mp4" width="800"></video>
</p>

---

## 🚀 Características Principales
* [cite_start]**Visualización Inmersiva:** Modelos 3D detallados de los monumentos del Sendero del Arte[cite: 2998, 3000].
* [cite_start]**Interactividad Táctil:** Los usuarios pueden escalar, rotar y mover los monumentos en su entorno físico[cite: 3000, 3111].
* [cite_start]**Información Técnica:** Cada obra incluye detalles sobre el artista, peso y dimensiones[cite: 2999].
* [cite_start]**Captura y Compartición:** Incluye un sistema para tomar capturas de pantalla y compartirlas directamente a través de redes sociales[cite: 2969, 3069].

## 🛠️ Stack Tecnológico
* [cite_start]**Motor de Desarrollo:** Unity 2022.3.21f1[cite: 2996, 3442].
* [cite_start]**Lenguaje de Programación:** C#[cite: 3150, 3615].
* [cite_start]**SDK de Realidad Aumentada:** Google ARCore 1.9 o superior[cite: 3003, 3450].
* **Modelado y Texturizado:**
  * [cite_start]**Autodesk Maya:** Creación de mallas y mapas UV[cite: 3433].
  * [cite_start]**Adobe Substance Painter:** Texturizado realista de las obras[cite: 3434].
* **Plugins Clave:**
  * [cite_start]**AR Foundation:** Gestión de la sesión de RA y detección de planos[cite: 3450, 3552].
  * [cite_start]**DOTween:** Animaciones fluidas de la interfaz de usuario[cite: 2462, 2592].
  * [cite_start]**NativeShare:** Implementación de la funcionalidad de compartir archivos[cite: 2177, 2230].

## 🏗️ Arquitectura de la Aplicación
[cite_start]El desarrollo se basa en un sistema de gestores (*Managers*) que controlan la lógica del proyecto[cite: 1862]:
* [cite_start]**`ARInteractionManager`**: Controla el despliegue de modelos y las transformaciones (escala, rotación, posición)[cite: 1867, 1910].
* [cite_start]**`DataManager`**: Gestiona la carga de información desde `ScriptableObjects` para poblar el inventario[cite: 1874, 1876, 2233].
* [cite_start]**`InfoPanelManager`**: Despliega dinámicamente los datos técnicos de cada escultura[cite: 1888, 1889, 2299].
* [cite_start]**`UIManager`**: Maneja las transiciones entre el menú principal, inventario y modo RA[cite: 2461, 2462].
* [cite_start]**`GameManager`**: Centraliza los eventos y asegura una instancia única mediante el patrón Singleton[cite: 2600, 2601].

## 📱 Requisitos y Compatibilidad
* [cite_start]**Sistema Operativo:** Android 9.0 (Pie) o superior[cite: 3002, 3447].
* [cite_start]**Librerías:** Servicios de Google Play para RA (ARCore) instalados[cite: 3059, 3060].
* [cite_start]**Hardware:** Dispositivos compatibles con la API de profundidad de ARCore (ej. Google Pixel, Samsung Galaxy serie S/A, Xiaomi Redmi Note)[cite: 3005, 3008, 3028, 3047].

---
[cite_start]Desarrollado como proyecto de grado para el programa de **Ingeniería Multimedia** de la Universidad Militar Nueva Granada[cite: 3079, 3112].
