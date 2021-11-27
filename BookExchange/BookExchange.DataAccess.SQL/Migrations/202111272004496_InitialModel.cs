namespace BookExchange.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auteurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false),
                        DateParution = c.DateTime(nullable: false),
                        Resume = c.String(nullable: false),
                        Valeur = c.Double(nullable: false),
                        Etat = c.Int(nullable: false),
                        Commande_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commandes", t => t.Commande_Id)
                .Index(t => t.Commande_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomCategorie = c.String(nullable: false),
                        Livre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Livres", t => t.Livre_Id)
                .Index(t => t.Livre_Id);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCommande = c.DateTime(nullable: false),
                        Montant = c.Double(nullable: false),
                        DureeEnJours = c.Int(nullable: false),
                        Utilisateur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.Comptes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Solde = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        Ville = c.String(),
                        Username = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false),
                        ConfirmPWD = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Admin = c.Boolean(nullable: false),
                        Compte_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comptes", t => t.Compte_Id)
                .Index(t => t.Compte_Id);
            
            CreateTable(
                "dbo.LivreAuteurs",
                c => new
                    {
                        Livre_Id = c.Int(nullable: false),
                        Auteur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Livre_Id, t.Auteur_Id })
                .ForeignKey("dbo.Livres", t => t.Livre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Auteurs", t => t.Auteur_Id, cascadeDelete: true)
                .Index(t => t.Livre_Id)
                .Index(t => t.Auteur_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Utilisateurs", "Compte_Id", "dbo.Comptes");
            DropForeignKey("dbo.Commandes", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Livres", "Commande_Id", "dbo.Commandes");
            DropForeignKey("dbo.Categories", "Livre_Id", "dbo.Livres");
            DropForeignKey("dbo.LivreAuteurs", "Auteur_Id", "dbo.Auteurs");
            DropForeignKey("dbo.LivreAuteurs", "Livre_Id", "dbo.Livres");
            DropIndex("dbo.LivreAuteurs", new[] { "Auteur_Id" });
            DropIndex("dbo.LivreAuteurs", new[] { "Livre_Id" });
            DropIndex("dbo.Utilisateurs", new[] { "Compte_Id" });
            DropIndex("dbo.Commandes", new[] { "Utilisateur_Id" });
            DropIndex("dbo.Categories", new[] { "Livre_Id" });
            DropIndex("dbo.Livres", new[] { "Commande_Id" });
            DropTable("dbo.LivreAuteurs");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Comptes");
            DropTable("dbo.Commandes");
            DropTable("dbo.Categories");
            DropTable("dbo.Livres");
            DropTable("dbo.Auteurs");
        }
    }
}
