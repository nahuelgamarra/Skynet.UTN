﻿using Logica.Desperfecto;
using Logica.Operadores;

namespace Desperfecto
{
    public class MotorComprometido : Desperfecto
    {
        public MotorComprometido(string descripcion) : base(descripcion, TipoDesperfecto.MotorComprometido)
        {
        }

        public override void AplicarDesperfecto(Operador operador)
        {
            ReducirVelocidadDeMotor(operador);
        }

        private void ReducirVelocidadDeMotor(Operador operador)
        {
            operador.VelocidadOptima = operador.VelocidadOptima / 2;
        }
    }
}
