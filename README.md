Optical Module Test Station Simulator

A C# console application simulating an automated production test station for optical transceiver modules, modeled on the architecture used in real manufacturing test software for optical communications equipment.
The application runs a configurable sequence of functional tests against simulated lab instruments (optical power meter, optical spectrum analyzer, tunable laser source), evaluates each measurement against product-specific pass/fail limits, and generates a structured CSV test report — mirroring the workflow of a real factory test station.
Architecture highlights:

Instrument communication is abstracted behind interfaces (IInstrument), so simulated devices can be swapped for real VISA/SCPI-controlled hardware without changing test logic
Test limits and product configuration are externalized to JSON, supporting multiple products across NPI to end-of-life
A test sequencer runs steps in order, with critical-failure handling that aborts and skips remaining steps — matching real production behavior
Each test step is an independent, swappable unit (ITestStep), following common test automation design patterns

Tech stack: C# / .NET, JSON configuration, CSV reporting

Built as a self-directed learning project to explore manufacturing test automation concepts and C# OOP design patterns.
