using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MCRAFT_DMSQ
{
    public class Braço
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Game1 G1;
        public Braço(GraphicsDevice device)
        {
            this.device = device;
            this.world = Matrix.Identity;

            G1 = new Game1();
            verts = new VertexPositionColor[] {
            //verts[0] = new VertexPositionColor(new Vector3(0.5f, 0, 0.5f), Color.DarkBlue);
            //verts[1] = new VertexPositionColor(new Vector3(0.5f, 0, -0.5f), Color.DarkBlue);
            //verts[2] = new VertexPositionColor(new Vector3(-0.5f, 0, -0.5f), Color.DarkBlue);
            //verts[3] = new VertexPositionColor(new Vector3(-0.5f, 0, -0.5f), Color.DarkBlue);
            //verts[4] = new VertexPositionColor(new Vector3(-0.5f, 0, 0.5f), Color.DarkBlue);
            //verts[5] = new VertexPositionColor(new Vector3(0.5f, 0, 0.5f), Color.DarkBlue);

            new VertexPositionColor(new Vector3(0.25f, -0f, 0), Color.Blue),  //Frente T0.25ff-T2
                new VertexPositionColor(new Vector3(-0.25f, -0f, 0), Color.Blue),
                new VertexPositionColor(new Vector3(-0.25f, 1f, 0), Color.Blue),

                new VertexPositionColor(new Vector3(0.25f, 1f, 0), Color.Blue),
                new VertexPositionColor(new Vector3(0.25f, -0f, 0), Color.Blue),
                new VertexPositionColor(new Vector3(-0.25f, 1f, 0), Color.Blue),

                new VertexPositionColor(new Vector3(0.25f, -0f, -0.25f), Color.Blue),   //Fundos T3-T4
                new VertexPositionColor(new Vector3(-0.25f, -0f, -0.5f), Color.Blue),
                new VertexPositionColor(new Vector3(-0.25f, 1f, -0.25f), Color.Blue),

                new VertexPositionColor(new Vector3(0.25f, 1f, -0.25f), Color.Blue),
                new VertexPositionColor(new Vector3(0.25f, -0f, -0.25f), Color.Blue),
                new VertexPositionColor(new Vector3(-0.25f, 1f, -0.25f), Color.Blue),

                new VertexPositionColor(new Vector3(-0.25f, 1f, -0.25f), Color.Blue),   //Janela Lá T5-T6
                new VertexPositionColor(new Vector3(-0.25f, -0f, -0.25f), Color.Blue),
                new VertexPositionColor(new Vector3(-0.25f, -0f, 0), Color.Blue),

                new VertexPositionColor(new Vector3(-0.25f, 1f, -0.25f), Color.Blue),
                new VertexPositionColor(new Vector3(-0.25f, -0f, 0), Color.Blue),
                new VertexPositionColor(new Vector3(-0.25f, 1f, 0), Color.Blue),

                new VertexPositionColor(new Vector3(0.25f, 1f, -0.25f), Color.Blue),   //Janela Cá T7-T8
                new VertexPositionColor(new Vector3(0.25f, -0f, -0.25f), Color.Blue),
                new VertexPositionColor(new Vector3(0.25f, -0f, 0), Color.Blue),

                new VertexPositionColor(new Vector3(0.25f, 1f, -0.25f), Color.Blue),
                new VertexPositionColor(new Vector3(0.25f, -0f, 0), Color.Blue),
                new VertexPositionColor(new Vector3(0.25f, 1f, 0), Color.Blue),

                new VertexPositionColor(new Vector3(0.25f, 1f, 0), Color.Blue),   //Teto T9-T0.25f0
                new VertexPositionColor(new Vector3(-0.25f, 1f, 0), Color.Blue),
                new VertexPositionColor(new Vector3(-0.25f, 1f, -0.25f), Color.Blue),
                };

            this.buffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionColor),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.buffer.SetData<VertexPositionColor>(this.verts);

            this.effect = new BasicEffect(this.device);
        }

        public void Draw(_Camera camera, Vector3 position, Vector3 scale)
        {
            this.device.SetVertexBuffer(this.buffer);

            this.effect.World = this.world;
            this.effect.View = camera.GetView();
            this.effect.Projection = camera.GetProjection();
            this.effect.VertexColorEnabled = true;



            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                world = Matrix.CreateTranslation(position);
                world *= Matrix.CreateScale(scale);


                this.device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, this.verts, 0, 9); //Fundo
            }

        }

    }
}
