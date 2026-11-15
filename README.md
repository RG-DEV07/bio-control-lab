# BioControlLab

Sistema de escritorio (Windows Forms, C#) para gestionar un laboratorio clínico: pacientes, médicos, citas, instrumentos, exámenes y reportes, con base de datos SQL Server.

## Estructura
```
app/                      Proyecto principal (WinForms)
BioControlLab.sln         Solución de Visual Studio
base-de-datos/scripts/    Scripts SQL para crear la base y sus relaciones
docs/diagramas/           Modelo relacional
```

## Requisitos
- Visual Studio con .NET Framework
- SQL Server (ejecutar los scripts de `base-de-datos/scripts/` en orden)
- Restaurar los paquetes NuGet al abrir la solución

## Configuración
La cadena de conexión está en `app/App.config`. Ajústala a tu servidor local antes de ejecutar.
