using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using RobotArm.Data.DbContexts.RobotArmControl;
using RobotArm.Data.Entities.RobotArmControl;

namespace RobotArm.Data.SeedData.RobotArmControl
{
    public class RobotArmControlSeedData : CreateDatabaseIfNotExists<RobotArmControlDbContext>
    {
        protected override void Seed(RobotArmControlDbContext context)
        {
            var stepDefinitions = this.GetStepDefinitions();

            foreach (var stepDefinition in stepDefinitions)
            {
                context.StepDefinition.AddOrUpdate(stepDefinition);
                context.SaveChanges();
            }

            var programs = this.GetPrograms("seed", 4, context);

            foreach (var program in programs)
            {
                context.RobotProgram.AddOrUpdate(program);
                context.SaveChanges();
            }

            base.Seed(context);
        }

        private RobotProgram[] GetPrograms(string namePrefix, int numberOfPrograms, RobotArmControlDbContext context)
        {
            var programs = new List<RobotProgram>();

            for (int i = 0; i < numberOfPrograms; i++)
            {
                programs.Add(GetProgram(namePrefix + "_program" + i, numberOfPrograms + i, numberOfPrograms + 2*i, numberOfPrograms + 3*i, context));
            }

            return programs.ToArray();
        }

        private RobotProgram GetProgram(string name, int numberOfSteps, int numberOfCartesianPoinst, int numberOfJointPoints, RobotArmControlDbContext context)
        {
            return new RobotProgram
            {
                Name = name,
                ProgramSteps = GetSteps(name, numberOfSteps, numberOfCartesianPoinst, numberOfJointPoints, context)
            };
        }

        private ProgramStep[] GetSteps(string namePrefix, int numberOfSteps, int numberOfCartesianPoinst, int numberOfJointPoints, RobotArmControlDbContext context)
        {
            var steps = new List<ProgramStep>();

            for (int i = 0; i < numberOfSteps; i++)
            {
                steps.Add(GetStep(namePrefix + "_step" + i, (i % context.StepDefinition.Count()) + 1, numberOfCartesianPoinst, numberOfJointPoints, context));
            }

            return steps.ToArray();
        }

        private ProgramStep GetStep(string name, int stepDefinitionId, int numberOfCartesianPoinst, int numberOfJointPoints, RobotArmControlDbContext context)
        {
            return new ProgramStep
            {
                Name = name,
                CartesianPoints = GetCartesianPoints(name, numberOfCartesianPoinst),
                JointPoints = GetJointPoints(name, numberOfJointPoints),
                Step = context.StepDefinition.First(s => s.BusinessId == stepDefinitionId)
            };
        }

        private StepDefinition[] GetStepDefinitions()
        {
            return new StepDefinition[]
            {
                GetStepDefinition(1, "MOVE", "Move optimal"),
                GetStepDefinition(2, "MOVE_J", "Move in joint mode"),
                GetStepDefinition(3, "MOVE_L", "Move in line mode")
            };
        }

        private StepDefinition GetStepDefinition(int businessId, string name, string description = "")
        {
            return new StepDefinition
            {
                BusinessId = businessId,
                Name = name,
                Description = description
            };
        }

        private CartesianPoint[] GetCartesianPoints(string namePrefix, int numberOfPoints)
        {
            var points = new List<CartesianPoint>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                points.Add(GetCartesianPoint(namePrefix + "_cp" + i, i));
            }

            return points.ToArray();
        }

        private CartesianPoint GetCartesianPoint(string name, double x = 0, double y = 0, double z = 0, double alpha = 0, double beta = 0, double gamma = 0)
        {
            return new CartesianPoint
            {
                Name = name,
                X = x,
                Y = y,
                Z = z,
                Alpha = alpha,
                Beta = beta,
                Gamma = gamma
            };
        }

        private JointPoint[] GetJointPoints(string namePrefix, int numberOfPoints)
        {
            var points = new List<JointPoint>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                points.Add(GetJointPoint(namePrefix + "_jp" + i, i));
            }

            return points.ToArray();
        }

        private JointPoint GetJointPoint(string name, double n1 = 0, double n2 = 0, double n3 = 0, double n4 = 0, double n5 = 0, double n6 = 0)
        {
            return new JointPoint
            {
                Name = name,
                N1 = n1,
                N2 = n2,
                N3 = n3,
                N4 = n4,
                N5 = n5,
                N6 = n6
            };
        }
    }
}