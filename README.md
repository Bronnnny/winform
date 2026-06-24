# 温度采集与监控系统（上位机）

基于 C# WinForm 开发的上位机温度采集程序，用于通过串口接收设备温度数据，实时显示并存入数据库。

## 技术栈

- C# WinForm
- SerialPort 串口通信
- SQL Server 数据库
- 多线程 / Timer / 锁机制

## 功能说明

- 串口参数配置（端口号、波特率）
- 实时温度数据显示
- 数据自动存入 SQL Server
- 历史数据查询（DataGridView）
- 界面防卡顿（缓存 + 定时刷新）

## 运行环境

- Visual Studio 2019 / 2022
- .NET Framework 4.7.2
- SQL Server 2012 或更高版本

## 项目结构

- Form1.cs：主界面逻辑
- ModbusReader.cs：Modbus 通信
- Sqlserver1.cs：数据库操作
